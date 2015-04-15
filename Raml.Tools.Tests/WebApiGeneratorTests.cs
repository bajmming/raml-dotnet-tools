﻿using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Raml.Parser;
using Raml.Tools.WebApiGenerator;

namespace Raml.Tools.Tests
{
	[TestFixture]
	public class WebApiGeneratorTests
	{
		[Test]
		public async void Should_Generate_Controller_Objects_When_Movies()
		{
			var model = await GetMoviesGeneratedModel();
			Assert.AreEqual(2, model.Controllers.Count());
		}

		[Test]
		public async void Should_Generate_Controller_Objects_When_Box()
		{
			var model = await GetBoxGeneratedModel();
			Assert.AreEqual(10, model.Controllers.Count());
		}

		[Test]
		public async void Should_Generate_Controller_Objects_When_Congo()
		{
			var model = await GetCongoGeneratedModel();
			Assert.AreEqual(2, model.Controllers.Count());
		}

		[Test]
		public async void Should_Generate_Controller_Objects_When_Contacts()
		{
			var model = await GetContactsGeneratedModel();
			Assert.AreEqual(2, model.Controllers.Count());
		}

		[Test]
		public async void Should_Generate_Controller_Objects_When_GitHub()
		{
			var model = await GetGitHubGeneratedModel();
			Assert.AreEqual(17, model.Controllers.Count());
		}

		[Test]
		public async void Should_Generate_Controller_Objects_When_Instagram()
		{
			var model = await GetInstagramGeneratedModel();
			Assert.AreEqual(7, model.Controllers.Count());
		}

		[Test]
		public async void Should_Generate_Controller_Objects_When_Large()
		{
			var model = await GetLargeGeneratedModel();
			Assert.AreEqual(10, model.Controllers.Count());
		}

		[Test]
		public async void Should_Generate_Controller_Objects_When_Regression()
		{
			var model = await GetRegressionGeneratedModel();
			Assert.AreEqual(2, model.Controllers.Count());
		}

		[Test]
		public async void Should_Generate_Controller_Objects_When_Test()
		{
			var model = await GetTestGeneratedModel();
			Assert.AreEqual(2, model.Controllers.Count());
		}

		[Test]
		public async void Should_Generate_Controller_Objects_When_Twitter()
		{
			var model = await GetTwitterGeneratedModel();
			Assert.AreEqual(16, model.Controllers.Count());
		}

		[Test]
		public async void Should_Remove_Not_Used_Objects_Dars()
		{
			var model = await GetDarsGeneratedModel();
			Assert.AreEqual(2, model.Objects.Count());
		}

		[Test]
		public async void Should_Not_Remove_Used_Objects_Twitter()
		{
			var model = await GetTwitterGeneratedModel();
			Assert.IsTrue(model.Objects.Any(o => o.Value.Name == "ContainedWithin"));
			Assert.AreEqual(53, model.Objects.Count());
		}

		[Test]
		public async void Should_Name_Schemas_Using_Keys()
		{
			var model = await GetSchemaTestsGeneratedModel();
			Assert.IsTrue(model.Objects.Any(o => o.Value.Name == "Thing"));
			Assert.IsTrue(model.Objects.Any(o => o.Value.Name == "Things"));
            Assert.IsTrue(model.Objects.Any(o => o.Value.Name == "ThingResult"));
            Assert.IsTrue(model.Objects.Any(o => o.Value.Name == "ThingRequest"));
			Assert.AreEqual(5, model.Objects.Count());
		}

        [Test]
        public async void Should_Generate_Properties_When_Movies()
        {
            var model = await GetMoviesGeneratedModel();
            Assert.AreEqual(82, model.Objects.Sum(c => c.Value.Properties.Count));
        }

        [Test]
        public async void Should_Generate_Properties_When_Box()
        {
            var model = await GetBoxGeneratedModel();
            Assert.AreEqual(17, model.Objects.Sum(c => c.Value.Properties.Count));
        }

        [Test]
        public async void Should_Generate_Properties_When_Congo()
        {
            var model = await GetCongoGeneratedModel();
            Assert.AreEqual(26, model.Objects.Sum(c => c.Value.Properties.Count));
        }

        [Test]
        public async void Should_Generate_Properties_When_Contacts()
        {
            var model = await GetContactsGeneratedModel();
            Assert.AreEqual(3, model.Objects.Sum(c => c.Value.Properties.Count));
        }

        [Test]
        public async void Should_Generate_Properties_When_GitHub()
        {
            var model = await GetGitHubGeneratedModel();
            Assert.AreEqual(345, model.Objects.Sum(c => c.Value.Properties.Count));
        }

        [Test]
        public async void Should_Generate_Properties_When_Instagram()
        {
            var model = await GetInstagramGeneratedModel();
            Assert.AreEqual(21, model.Objects.Sum(c => c.Value.Properties.Count));
        }

        [Test]
        public async void Should_Generate_Properties_When_Large()
        {
            var model = await GetLargeGeneratedModel();
            Assert.AreEqual(17, model.Objects.Sum(c => c.Value.Properties.Count));
        }

        [Test]
        public async void Should_Generate_Properties_When_Regression()
        {
            var model = await GetRegressionGeneratedModel();
            Assert.AreEqual(60, model.Objects.Sum(c => c.Value.Properties.Count));
        }

        [Test]
        public async void Should_Generate_Properties_When_Test()
        {
            var model = await GetTestGeneratedModel();
            Assert.AreEqual(20, model.Objects.Sum(c => c.Value.Properties.Count));
        }

        [Test]
        public async void Should_Generate_Properties_When_Twitter()
        {
            var model = await GetTwitterGeneratedModel();
            Assert.AreEqual(302, model.Objects.Sum(c => c.Value.Properties.Count));
        }


		private static async Task<WebApiGeneratorModel> GetTestGeneratedModel()
		{
			var raml = await new RamlParser().LoadAsync("test.raml");
			var model = new WebApiGeneratorService(raml).BuildModel();

			return model;
		}

		private static async Task<WebApiGeneratorModel> GetBoxGeneratedModel()
		{
			var raml = await new RamlParser().LoadAsync("box.raml");
			var model = new WebApiGeneratorService(raml).BuildModel();

			return model;
		}


		private async Task<WebApiGeneratorModel> GetLargeGeneratedModel()
		{
			var raml = await new RamlParser().LoadAsync("large.raml");

			var model = new WebApiGeneratorService(raml).BuildModel();
			return model;
		}

		private async Task<WebApiGeneratorModel> GetRegressionGeneratedModel()
		{
			var raml = await new RamlParser().LoadAsync("regression.raml");

			var model = new WebApiGeneratorService(raml).BuildModel();
			return model;
		}

		private async Task<WebApiGeneratorModel> GetCongoGeneratedModel()
		{
			var parser = new RamlParser();
			var raml = await parser.LoadAsync("congo-drones-5-f.raml");
			return new WebApiGeneratorService(raml).BuildModel();
		}

		private async Task<WebApiGeneratorModel> GetInstagramGeneratedModel()
		{
			var parser = new RamlParser();
			var raml = await parser.LoadAsync("instagram.raml");
			return new WebApiGeneratorService(raml).BuildModel();
		}

		private async Task<WebApiGeneratorModel> GetTwitterGeneratedModel()
		{
			var parser = new RamlParser();
			var raml = await parser.LoadAsync("twitter.raml");
			return new WebApiGeneratorService(raml).BuildModel();
		}

		private async Task<WebApiGeneratorModel> GetGitHubGeneratedModel()
		{
			var parser = new RamlParser();
			var raml = await parser.LoadAsync("github.raml");
			return new WebApiGeneratorService(raml).BuildModel();
		}

		private async Task<WebApiGeneratorModel> GetContactsGeneratedModel()
		{
			var parser = new RamlParser();
			var raml = await parser.LoadAsync("contacts.raml");
			return new WebApiGeneratorService(raml).BuildModel();
		}

		private static async Task<WebApiGeneratorModel> GetMoviesGeneratedModel()
		{
			var raml = await new RamlParser().LoadAsync("movies.raml");
			var model = new WebApiGeneratorService(raml).BuildModel();

			return model;
		}

		private static async Task<WebApiGeneratorModel> GetDarsGeneratedModel()
		{
			var raml = await new RamlParser().LoadAsync("dars.raml");
			var model = new WebApiGeneratorService(raml).BuildModel();

			return model;
		}

		private static async Task<WebApiGeneratorModel> GetSchemaTestsGeneratedModel()
		{
			var raml = await new RamlParser().LoadAsync("schematests.raml");
			var model = new WebApiGeneratorService(raml).BuildModel();

			return model;
		}

	}
}