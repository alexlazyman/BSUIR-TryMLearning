namespace TryMLearning.Model.Account
{
    public class UserChangePasswordForm
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }
    }
}