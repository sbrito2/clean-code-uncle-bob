using System;
using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.CoreLogic.Entities.Base
{
    public abstract class Entity : ITimestampedModel, ISoftDeleteModel
    {
        public int Id { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UserId { get; set; }


        [NotMapped]
		public ValidationResult ValidationResult { get; private set; }

        
        public bool IsValid<TModel>(TModel model, AbstractValidator<TModel> validator)
		{
			ValidationResult = validator.Validate(model);
			return ValidationResult.IsValid;
		}
        
        public abstract bool IsValid();
    }
}
