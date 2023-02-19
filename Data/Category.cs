using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesTutorial.Data
{
	public class Category
	{
		public int Id{ get; set; }
		[Required]

		public string? Name { get; set; }

	}
}

