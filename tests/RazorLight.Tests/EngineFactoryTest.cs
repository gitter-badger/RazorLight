﻿using System;
using Xunit;

namespace RazorLight.Tests
{
	public class EngineFactoryTest
	{
		private readonly string viewsRoot = PathUtility.GetViewsPath();

		[Fact]
		public void PhysicalFactory_Throws_On_RootNull()
		{
			var action = new Action(() => EngineFactory.CreatePhysical(null));

			Assert.Throws<ArgumentNullException>(action);
		}

		[Fact]
		public void Ensure_Passed_Configuration_Is_Applided_OnPhysical()
		{
			IEngineConfiguration configuration = EngineConfiguration.Default;

			var engine = EngineFactory.CreatePhysical(viewsRoot, configuration);

			Assert.Same(configuration, engine.Configuration);
		}

		[Fact]
		public void Ensure_Passed_Configuration_Is_Applided_OnEmbedded()
		{
			IEngineConfiguration configuration = EngineConfiguration.Default;

			var engine = EngineFactory.CreateEmbedded(typeof(TestViewModel), configuration);

			Assert.Same(configuration, engine.Configuration);
		}

	}
}
