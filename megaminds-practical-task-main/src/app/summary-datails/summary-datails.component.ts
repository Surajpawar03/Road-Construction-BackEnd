import { Component, OnInit } from '@angular/core';
import { SummaryService } from '../services/summary.service';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-summary-datails',
  templateUrl: './summary-datails.component.html',
  styleUrls: ['./summary-datails.component.scss']
})
export class SummaryDatailsComponent implements OnInit {
  public summaryForm: any = [];
  public summaryList: any = [];
  public selectedSummaryData: any = [];
  constructor(
    private summaryService: SummaryService,
    private fb: FormBuilder,
    private router: Router) {
    this.formInIt();
  }

  private formInIt() {
    this.summaryForm = this.fb.group({
      projectname: [''],
      constructioncount: [''],
      isconstructioncompleted: [''],
      lengthoftheroad: [''],
    })
  }

  ngOnInit(): void {
    this.summaryService.getSummary().subscribe({
      next: (res) => {
        this.summaryList = res;
        if (this.summaryList && this.summaryList.length > 0) {
          this.showSummaryData(this.summaryList[0]);
        } else {
          console.warn("No summary data available.");
        }
      },
      error: (err) => {
        console.error("Error fetching summary data:", err);
      }
    });
    
  }

  public showSummaryData(summaryObj: any) {
    debugger
    this.selectedSummaryData = summaryObj;
    summaryObj.Properties.forEach((property: any) => {
      const propertyName = property.Label.toLowerCase().replace(/ /g, '');
      let controls = this.summaryForm.get(propertyName)
      if (controls !== null) {
        controls.setValue(property.Value || null);
      }
    });
  }

  public updateSummary() {
    let formValue = this.convertDataPayload();
    this.summaryService.updateSummary(this.selectedSummaryData.id, formValue).subscribe((res: any) => {
      this.router.navigateByUrl('');
      Swal.fire({
        position: "center",
        icon: "success",
        title: "summary has been updated",
        showConfirmButton: false,
        timer: 1500
      });
    })
  }

  private convertDataPayload() {
    let obj = Object.entries(this.summaryForm.value).map(([key, value]) => {
      let label = ""
      switch (key) {
        case "projectname":
          label = "Project Name"
          break;
        case "constructioncount":
          label = "Construction Count"
          break;
        case "isconstructioncompleted":
          label = "Is Construction Completed"
          break;
        case "lengthoftheroad":
          label = "Length of the road"
          break;
        default:
          break;
      }
      return { Label: label, Value: value }
    })
    const result = {
      SamplingTime: this.selectedSummaryData.SamplingTime,
      Properties: obj
    };
    return result;
  }

}
