using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpNote.Kernel
{
    public class NoteKernel : CommonKernel
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public UserKernel Creator { get; set; }
        public List<UserKernel> Permissions;

        public DateTime? AppearAt { get; set; }
        public DateTime? ExpireAt { get; set; }

        public bool IsAvailible()
        {
            if (AppearAt.HasValue)
            {
                if (DateTime.Compare(DateTime.Now, AppearAt.GetValueOrDefault()) > 0)
                {
                    if (ExpireAt.HasValue)
                    {
                        if (DateTime.Compare(ExpireAt.GetValueOrDefault(), DateTime.Now) > 0)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            else if (ExpireAt.HasValue)
            {
                if (DateTime.Compare(this.ExpireAt.GetValueOrDefault(), DateTime.Now) > 0)
                {
                    return true;
                }
            }
            else
            {
                return true;
            }

            return false;
        }
    }
}
