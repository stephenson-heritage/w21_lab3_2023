using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace lab3.Pages_Profile
{
	public class EditModel : PageModel
	{
		private readonly Lab3.Models.Lab3Context _context;
		private readonly ILogger<EditModel> _logger;

		public EditModel(Lab3.Models.Lab3Context context, ILogger<EditModel> logger)
		{
			_context = context;
			_logger = logger;
		}

		[BindProperty]
		public LabUser LabUser { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(uint? id)
		{
			if (id == null || _context.Users == null)
			{
				return NotFound();
			}

			var labuser = await _context.Users.FirstOrDefaultAsync(m => m.LabUserId == id);
			if (labuser == null)
			{
				return NotFound();
			}
			LabUser = labuser;
			return Page();
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			_logger.LogInformation("OnPostAsync");
			if (!ModelState.IsValid)
			{
				_logger.LogInformation("invalid modelstate");
				foreach (var ms in ModelState.Values)
				{
					foreach (var error in ms.Errors)
					{
						_logger.LogError(error.ErrorMessage);
					}
				}

				return Page();
			}

			_context.Attach(LabUser).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!LabUserExists(LabUser.LabUserId))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return RedirectToPage("./Details");
		}

		private bool LabUserExists(uint id)
		{
			return (_context.Users?.Any(e => e.LabUserId == id)).GetValueOrDefault();
		}
	}
}
