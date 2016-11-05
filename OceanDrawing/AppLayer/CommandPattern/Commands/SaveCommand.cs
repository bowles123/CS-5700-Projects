using AppLayer.DrawingComponents.DrawingObjects;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Amazon.S3;
using Amazon.S3.Model;
using System.Text;

namespace AppLayer.CommandPattern.Commands
{
    public class SaveCommand : Command
    {
        private readonly string file;
        internal SaveCommand() { ActualCommand = "SAVE"; }

        internal SaveCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
                file = commandParameters[0] as string;
            ActualCommand = "SAVE";
        }

        public override bool Execute()
        {
            if (string.IsNullOrWhiteSpace(file) || Drawing == null) return false;
            try
            {
                AmazonS3Client client = new AmazonS3Client();
                MemoryStream stream = new MemoryStream();
                List<ExtrinsicSeaCreature> extrinsicStates = new List<ExtrinsicSeaCreature>();

                foreach (SeaCreature creature in Drawing?.SeaCreatures)
                {
                    SeaCreatureWithAllState seaCreature = creature as SeaCreatureWithAllState;
                    if (seaCreature != null)
                        extrinsicStates.Add(seaCreature.ExtrinsicState);
                }

                JsonSerializer.getInstance().getObjectSerializer().WriteObject(stream, extrinsicStates);
                string content = Encoding.ASCII.GetString(stream.ToArray());

                PutObjectRequest request = new PutObjectRequest()
                {
                    ContentBody = content,
                    BucketName = "usu5700-brianbowles",
                    Key = "HW3/" + file
                };

                PutObjectResponse response = client.PutObject(request);
                return true;
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
                    MessageBox.Show("An error occurred with the message '{0}' when writing an object", amazonS3Exception.Message);
                }
                return false;
            }
        }

        public override bool Undo() { return false; }
    }
}
