﻿using PipelineBehaviours.API.Common;

namespace PipelineBehaviours.API.Application.Messages.Commands;

public class CreateProductCommand : Command
{
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}
