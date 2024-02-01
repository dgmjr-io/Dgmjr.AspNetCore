namespace Dgmjr.Graph.Constants;

public class MsGraphScopes
{
    /// <value>https://graph.microsoft.com/</value>
    public const string Base = "https://graph.microsoft.com/";

    /// <value><inheritdoc cref="Base" path="/value" />.default</value>
    public const string Default = Base + ".default";

    public static class User
    {
        /// <value><inheritdoc cref="MsGraphScopes.Base" path="/value" />User.</value>
        private const string Base = MsGraphScopes.Base + "User.";

        public static class Read
        {
            /// <value><inheritdoc cref="User.Base" path="/value" />Read</value>
            public const string Base = User.Base + "Read";

            /// <value><inheritdoc cref="Base" path="/value" />.All</value>
            public const string All = Base + ".All";
            /// <value><inheritdoc cref="Base" path="/value" />Basic.All</value>
            public const string BasicAll = Base + "Basic.All";
        }

        public static class ReadWrite
        {
            /// <value><inheritdoc cref="User.Base" path="/value" />ReadWrite</value>
            public const string Base = User.Base + "ReadWrite";

            /// <value><inheritdoc cref="Base" path="/value" />.All</value>
            public const string All = Base + ".All";
        }

        public static class Invite
        {
            /// <value><inheritdoc cref="User.Base" path="/value" />Invite</value>
            private const string Base = User.Base + "Invite.";
            /// <value><inheritdoc cref="Base" path="/value" />.All</value>
            public const string All = Base + ".All";
        }

        public static class ManageIdentities
        {
            /// <value><inheritdoc cref="User.Base" path="/value" />ManageIdentities</value>
            private const string Base = User.Base + "ManageIdentities.";
            /// <value><inheritdoc cref="Base" path="/value" />.All</value>
            public const string All = Base + ".All";
        }

        public static class Export
        {
            /// <value><inheritdoc cref="User.Base" path="/value" />Export</value>
            private const string Base = User.Base + "Export.";
            /// <value><inheritdoc cref="Base" path="/value" />.All</value>
            public const string All = Base + ".All";
        }

        public static class EnableDisableAccount
        {
            /// <value><inheritdoc cref="User.Base" path="/value" />EnableDisableAccount</value>
            private const string Base = User.Base + "EnableDisableAccount.";
            /// <value><inheritdoc cref="Base" path="/value" />.All</value>
            public const string All = Base + ".All";
        }
    }

    public static class Directory
    {
        public const string Base = MsGraphScopes.Base + "Directory.";

        public static class Read
        {
            public const string Base = Directory.Base + "Read";

            public const string All = Base + ".All";
        }
    }
}
