using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesTutorial.Data
{
	public class Person
	{
		
		public int Id { get; set;}
		[Required]

		public string? Name { get; set; }
        [Required,EmailAddress]

        public string? Email { get; set; }

		public string? ProfilePicture { get; set; }

		[NotMapped]
		public IFormFile? ImageFile { get; set; }

    }
}

