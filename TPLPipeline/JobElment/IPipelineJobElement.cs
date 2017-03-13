﻿namespace TPLPipeLine
{
	public interface IPipelineJobElement
	{
		IPipelineJob Job { get; }
		int Element { get; }

		int CurrentStep { get; }
		int CompletedStep { get; }

		void BeginStep();
		void CompleteStep();

		void Disable();
		bool Disabled { get; }

		T GetData<T>();
		void SetData<T>(T value);
	}
}