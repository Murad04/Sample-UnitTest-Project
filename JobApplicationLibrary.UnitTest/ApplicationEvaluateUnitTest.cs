using NUnit.Framework;
using UniteTestProject;
using UniteTestProject.Enums;
using UniteTestProject.Models;

namespace JobApplicationLibrary.UnitTest
{
    public class ApplicationEvaluateUnitTest
    {
        [Test]
        public void Application_WithUnderAge_TransferredToAutoRejected()
        {
            // Arrange
            var evaluator = new ApplicationEvaluator();
            var form = new JobApplicant()
            {
                Applicant = new Applicant()
                {
                    Age = 17
                }
            };

            // Action
            var result = evaluator.Result(form);

            // Assert
            Assert.AreEqual(result, ApplicantionResult.AutoRejected);
        }

        [Test]
        public void Application_WithNoTechStack_TransferredToAutoRejected()
        {
            // Arrange
            var evaluator = new ApplicationEvaluator();
            var form = new JobApplicant()
            {
                Applicant = new Applicant(),
                TechStackList = new List<string>() { "" }
            };

            // Action
            var result = evaluator.Result(form);

            // Assert
            Assert.AreEqual(result, ApplicantionResult.AutoRejected);
        }

        [Test]
        public void Application_With75PTechStack_TransferredToAutoRejected()
        {
            // Arrange
            var evaluator = new ApplicationEvaluator();
            var form = new JobApplicant()
            {
                Applicant = new Applicant(),
                TechStackList = new List<string>() { "ASP.NET Core", "Microservices", "Unit Test", "Dapper" },
                YearsOfExperience = 9
            };

            // Action
            var result = evaluator.Result(form);

            // Assert
            Assert.AreEqual(result, ApplicantionResult.AutoRejected);
        }

    }
}