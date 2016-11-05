using System.Windows.Forms;
using System;

using Amazon.S3;
using Amazon.S3.Model;

namespace AppLayer.CommandPattern.Commands
{
    public class LoadCommand : Command
    {
        private string file;
        internal LoadCommand() { ActualCommand = "LOAD"; }

        internal LoadCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
                file = commandParameters[0] as string;
            ActualCommand = "LOAD";
        }

        public override bool Execute()
        {
            if (string.IsNullOrWhiteSpace(file) ||  Drawing == null) return false;
            Drawing.Clear();

            try
            {
                AmazonS3Client client = new AmazonS3Client();
                GetObjectRequest request = new GetObjectRequest()
                {
                    BucketName = "usu5700-brianbowles",
                    Key = "HW3/" + file
                };

                using (GetObjectResponse response = client.GetObject(request))
                {
                    Drawing?.Load(response.ResponseStream);
                    return true;
                }
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    MessageBox.Show("Please check the provided AWS Credentials.");
                    MessageBox.Show("If you haven't signed up for Amazon S3, please visit http://aws.amazon.com/s3");
                }
                else
                {
                    MessageBox.Show("An error occurred with the message '{0}' when reading an object", amazonS3Exception.Message);
                }
                return false;
            }
        }

        public override bool Undo() { return false; }
    }
}
