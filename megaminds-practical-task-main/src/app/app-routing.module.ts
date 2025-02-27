import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SummaryComponent } from './summary/summary.component';
import { SummaryDatailsComponent } from './summary-datails/summary-datails.component';

const routes: Routes = [
  { path: '', component: SummaryComponent },
  { path: 'summary-details', component: SummaryDatailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
