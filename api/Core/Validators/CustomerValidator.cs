using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede tener más de 50 caracteres.");
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede tener más de 50 caracteres.");
            RuleFor(x => x.Birthdate)
                .NotEmpty().WithMessage("La fecha de nacimiento es obligatoria.")
                .LessThan(DateTime.Today).WithMessage("La fecha de nacimiento no puede ser igual o mayor a la fecha actual.");
            RuleFor(x => x.Cuit)
                .NotEmpty().WithMessage("El CUIT es obligatorio.")
                .MinimumLength(11).WithMessage("El CUIT debe tener 11 caracteres.")
                .MaximumLength(11).WithMessage("El CUIT debe tener 11 caracteres.");
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("El teléfono es obligatorio.")
                .MaximumLength(50).WithMessage("El teléfono debe tener menos de 50 caracteres.");
            RuleFor(x => x.Email)
                .MaximumLength(50).WithMessage("El email debe tener menos de 100 caracteres.")
                .Must(IsValidEmail).WithMessage("El email ingresado no es válido.");
        }

        private bool IsValidEmail(string email)
        {
            var emailAddressAtribute = new EmailAddressAttribute();
            return emailAddressAtribute.IsValid(email);
        }
    }
}
