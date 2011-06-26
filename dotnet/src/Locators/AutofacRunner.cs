﻿using System;
using Dummies;
using Autofac;

namespace Locators
{
	public class AutofacRunner : ILocator
	{
		IContainer k;
		public string Name { get { return "Autofac"; } }

		public void WarmUp() {
			var builder = new ContainerBuilder();
			builder.RegisterType<SimpleDummy>().As<IDummy>().SingleInstance();
			k = builder.Build();
		}

		public void Run() {
			if (k.IsRegistered<IDummy>())
				k.Resolve<IDummy>().Do();
			else
				throw new InvalidOperationException(string.Format("{0} couldn't find a dummy to practice on.", this.Name));
		}
	}
}