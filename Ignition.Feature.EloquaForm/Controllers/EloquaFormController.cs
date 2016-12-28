using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ignition.FormIgnition.Sc.Contracts.Form;
using Ignition.FormIgnition.Sc.Mvc;

namespace Ignition.Feature.EloquaForm.Controllers
{
	public class EloquaFormController : IgnitionFormController
	{
		protected override IFormConfiguration Configuration { get; set; }
		protected override IFormAuthentication FormAuthentication { get; set; }
	}
}