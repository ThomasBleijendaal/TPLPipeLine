﻿using System;
using System.Collections.Generic;

namespace TPLPipeLine
{
	public class JobElement : IPipelineJobElement
	{
		public IPipelineJob Job { get; private set; }
		public int Element { get; private set; }

		public int CurrentStep { get; private set; } = 0;
		public int CompletedStep { get; private set; } = 0;
		public bool Disabled { get; private set; } = false;

		private List<object> _Data = new List<object>();

		public JobElement(IPipelineJob job, int element, object initData)
		{
			Job = job;
			Element = element;

			_Data.Add(initData);
		}

		T IPipelineJobElement.GetData<T>()
		{
			if (_Data[CompletedStep] is T data)
			{
				return data;
			}
			else
			{
				throw new Exception($"Could not get correct type of data for this step. (Step {CompletedStep}, Requested type {typeof(T)}, Stored data type {_Data[CompletedStep].GetType()})");
			}
		}

		void IPipelineJobElement.SetData<T>(T value)
		{
			_Data[CurrentStep] = value;
		}

		void IPipelineJobElement.BeginStep()
		{
			CurrentStep++;
			_Data.Add(null);
		}

		void IPipelineJobElement.CompleteStep()
		{
			if (CurrentStep > CompletedStep)
			{
				CompletedStep++;
			}
		}

		void IPipelineJobElement.Disable()
		{
			Disabled = true;
		}
		
		//// ILoggable
		//public Dictionary<string, int[]> events { get; set; } = new Dictionary<string, int[]>();

		//void ILoggable.AddEvent(int ms, int nr, string e)
		//{
		//	events.Add(e, new int[2] { ms, nr });
		//}

	}
}