namespace PlanningPoker.Core.Mapping
{
	using System;
	using System.Linq.Expressions;

	public interface IBaseMapper<TModel, TTarget>
	{
		//for queryable
		Expression<Func<TModel, TTarget>> ModelToTarget { get; }

		//map from POCO to DTO
		TTarget MapToTarget(TModel customer);

		//map to existing object
		TModel MapToExisting(TTarget dto, TModel customer);
	}
}
