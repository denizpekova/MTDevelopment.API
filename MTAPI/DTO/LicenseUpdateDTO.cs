namespace MTAPI.DTO
{
    public record LicenseUpdateDTO(
            string LicenseKey,
            string AllowedIp,
            string ServerName,
            int Status,
            DateTime? ExpireDate
        );
}
