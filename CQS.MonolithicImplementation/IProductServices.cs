﻿using CQS.Models;
using System;
using System.Collections.Generic;

namespace CQS.MonolithicImplementation
{
    public interface IProductServices
    {

        List<ProductListDTO> List();
        ProductDetailsDTO Get(Guid id);

        void Create(ProductCreateDTO productCreateDTO);

        void Edit(ProductEditDTO productEditDTO);

        void Delete(Guid id);
    }
}
