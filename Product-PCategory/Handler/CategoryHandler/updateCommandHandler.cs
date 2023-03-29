﻿using MediatR;
using Product_PCategory.Commands.CategoryCommands;
using Product_PCategory.DataAccess;

namespace Product_PCategory.Handler.CategoryHandler
{
    public class updateCommandHandler : IRequestHandler<UpdateCategoryCommand, string>
    {
        private readonly ICategory _category;

        public updateCommandHandler(ICategory category)
        {
            _category= category;
        }
        public Task<string> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
           return Task.FromResult(_category.UpdateCategory(request.updateCategory));
        }
    }
}
