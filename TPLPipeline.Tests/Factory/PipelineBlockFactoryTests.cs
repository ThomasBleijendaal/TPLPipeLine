﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPLPipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLPipeline.Tests
{
	[TestClass()]
	public class PipelineBlockFactoryTests
	{
		[TestMethod()]
		public void TransformBlockTest()
		{
			var block = PipelineBlockFactory.TransformBlock<IPipelineJob, string, string>((job, input) => input);
			Assert.IsNotNull(block);
		}
	}
}