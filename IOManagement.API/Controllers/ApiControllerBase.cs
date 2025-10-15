using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IOManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender? _mediator;

    // Mediator'ı servis container'dan al. ??= operatörü ile sadece ihtiyaç duyulduğunda alınmasını sağla.
    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
