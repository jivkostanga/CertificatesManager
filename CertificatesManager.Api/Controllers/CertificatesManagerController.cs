using CertificatesManager.Common.Models.GenerateCertificates;
using CertificatesManager.Common.Models.GetCertificate;
using CertificatesManager.Common.Models.GetCertificates;
using CertificatesManager.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CertificatesManager.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CertificatesManagerController : ControllerBase
{
    private readonly ICertificateService _certificateService;

    public CertificatesManagerController(ICertificateService certificateService)
    {
        _certificateService = certificateService;
    }

    [HttpPost("generate-certificates")]
    public async Task<ActionResult<GenerateCertificatesResponse>> Generate(
        GenerateCertificatesRequest request,
        CancellationToken cancellationToken)
    {
        return await _certificateService.GenerateCertificatesAsync(request, cancellationToken);
    }

    [HttpPost("get-certificate-by-serial-number")]
    public async Task<ActionResult<GetCertificateRequest>> Generate(
        GetCertificateRequest request,
        CancellationToken cancellationToken)
    {
        var res = await _certificateService.GetSertificateBySerialNumberAsync(request, cancellationToken);
        if (res == null)
        {
            return NotFound();
        }
        return Ok(res);
    }

    [HttpGet("get-certificates")]
    public async Task<ActionResult<GetCertificatesResponse>> GetCertificates(CancellationToken cancellationToken)
    {
        return Ok(await _certificateService.GetSertificatesAsync(cancellationToken));
    }
}
