using System;
using System.Collections.Generic;
using System.Text;

public interface ISmartphone
{
    List<string> PhoneNumbers { get; set; }

    List<string> WebAddresses { get; set; }
}