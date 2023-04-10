﻿using FluentValidation.Results;

namespace StockService.Validation
{
    public record ValidationFailed(IEnumerable<ValidationFailure> Errors)
    {
        public ValidationFailed(ValidationFailure error) : this(new[] { error })
        {

        }
    }
}