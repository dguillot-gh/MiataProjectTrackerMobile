// Models/Validation/TagValidationAttribute.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MiataProjectTracker.Mobile.Models.Validation
{
    public class TagValidationAttribute : ValidationAttribute
    {
        private static readonly List<string> AllowedTags = new()
        {
            "exhaust",
            "turbo",
            "engine",
            "body",
            "fuel",
            "suspension",
            "brakes",
            "interior",
            "exterior",
            "wheels",
            "intake",
            "cooling",
            "tuning"
        };

        public static List<string> GetAllowedTags()
        {
            return AllowedTags.ToList();
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return new ValidationResult("At least one tag is required.");
            }

            var tags = value.ToString()!.Split(',', StringSplitOptions.RemoveEmptyEntries);
            var invalidTags = tags.Where(t => !AllowedTags.Contains(t.Trim().ToLower())).ToList();

            if (invalidTags.Any())
            {
                return new ValidationResult($"Invalid tags: {string.Join(", ", invalidTags)}");
            }

            return ValidationResult.Success;
        }
    }
}