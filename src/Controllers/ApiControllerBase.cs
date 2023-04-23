/*
 * ApiControllerBase.cs
 *
 *   Created: 2022-12-10-05:39:52
 *   Modified: 2022-12-10-05:39:52
 *
 *   Author: David G. Moore, Jr, <david@dgmjr.io>
 *
 *   Copyright © 2022-2023 David G. Moore, Jr,, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Dgmjr.AspNetCore.Controllers;

using Dgmjr.Abstractions;
using Dgmjr.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Abstractions;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("api/[controller]")]
[Produces400Error, Produces401Error, Produces403Error, Produces404Error, Produces500Error]
public abstract class ApiControllerBase : ControllerBase, ILog
{
    public ILogger Logger { get; }

    protected ApiControllerBase(ILogger logger) => Logger = logger;
}

public abstract class ApiControllerBase<TDbContext> : ApiControllerBase, IHaveADbContext<TDbContext>
    where TDbContext : IDbContext, IDbContext<TDbContext>
{
    IDbContext IHaveADbContext.Db => Db;
    public TDbContext Db { get; }

    protected ApiControllerBase(TDbContext dbContext, ILogger logger) : base(logger) => Db = dbContext;
}
