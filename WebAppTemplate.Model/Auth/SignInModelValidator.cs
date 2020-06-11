using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WebAppTemplate.Model.Validation;

namespace WebAppTemplate.Model.Auth
{
    public class SignInModelValidator : Validator<SignInModel>
    {
        public SignInModelValidator()
        {
            WithMessage("Teste");
            RuleFor(signInModel => signInModel.Username).NotEmpty();
            RuleFor(signInModel => signInModel.Password).NotEmpty();
            RuleFor(signInModel => signInModel.Grant_Type).Must(BeAValidGrantType).NotEmpty();
        }

        private bool BeAValidGrantType(string grantType)
        {
            if (grantType == "password" || grantType == "refresh_token")
            {
                return true;
            }

            return false;
        }
    }
}
