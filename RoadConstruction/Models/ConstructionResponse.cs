using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

public class Property
{

    public string Label { get; set; }


    public object Value { get; set; }
}

public class ConstructionResponse
{
    public DateTimeOffset SamplingTime { get; set; }
    public List<Property> Properties { get; set; }
    public string Id { get; set; }
}
public class ConstructionRequest
{
    public int Id { get; set; }  
    public DateTimeOffset SamplingTime { get; set; }
    public List<Property> Properties { get; set; }
}