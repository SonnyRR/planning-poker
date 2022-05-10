﻿namespace PlanningPoker.Persistence.Entities
{
	public class BaseDeletableEntity<TKey> : BaseEntity<TKey>, IDeletableEntity
		 where TKey : struct, IComparable<TKey>, IEquatable<TKey>
	{
		public DateTimeOffset? DeletedOn { get; set; }

		public bool IsDeleted { get; set; }
	}
}
