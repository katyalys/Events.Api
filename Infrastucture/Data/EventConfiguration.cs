using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Data
{
	internal class EventConfiguration : IEntityTypeConfiguration<Event>
	{
		public void Configure(EntityTypeBuilder<Event> builder)
		{
			builder.Property(d => d.Speaker).HasMaxLength(15);
			builder.Property(d => d.Organizer).HasMaxLength(15);
			builder.Property(d => d.Location).HasMaxLength(15);
			builder.Property(d => d.Plan).HasMaxLength(50);
			builder.Property(d => d.Description).HasMaxLength(50);
		}
	}
}
