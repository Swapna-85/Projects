namespace KeypadTracer.Settings
{
    public record struct PhoneNumberSettings(int RequiredLength, char[] InvalidDigits, char[] InvalidStartDigits);

}
