﻿using UniteTestProject.Enums;
using UniteTestProject.Models;
using UniteTestProject.Services;

namespace UniteTestProject
{
    public class ApplicationEvaluator
    {
        private const int MinAge = 18;
        private const int AcceptedYears = 18;
        private List<string> techStackList = new() { "ASP.NET Core", "Unit Test", "Microservices", "Dapper" };
        private IdentityValidator identityValidator;

        public ApplicationEvaluator(IdentityValidator identityValidator)
        {
            this.identityValidator = identityValidator;
        }

        public ApplicantionResult Result(JobApplicant applicant)
        {
            if (applicant.Applicant.Age < MinAge)
            {
                return ApplicantionResult.AutoRejected;
            }

            var validIdentity = identityValidator.IsValid(applicant.Applicant.IdentityNumber);
            if (!validIdentity)
                return ApplicantionResult.TransferredToHR;

            var sr = GetTechStackSimilarityRate(applicant.TechStackList);
            if (sr < 25)
                return ApplicantionResult.AutoRejected;
            if (sr > 75 && applicant.YearsOfExperience >= AcceptedYears)
                return ApplicantionResult.AutoAccepted;
            return ApplicantionResult.AutoAccepted;
        }

        private int GetTechStackSimilarityRate(List<string> techStacks)
        {
            var matchCount =
                techStacks.Where(i => techStackList.Contains(i, StringComparer.OrdinalIgnoreCase))
                .Count();

            return (int)((double)matchCount / techStackList.Count) * 100;
        }
    }
}