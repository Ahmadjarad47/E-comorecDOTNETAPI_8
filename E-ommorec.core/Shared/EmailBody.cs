﻿namespace E_commorec.core.Shared
{
    public class EmailBody
    {
        public static string EmailStringBody(string email, string emailToken, string mesg, string component)
        {

            string encodedEmailToken = Uri.EscapeDataString(emailToken);

            return $@"<html>
<head>
  <style>
    body {{
      display: flex;
      justify-content: center;
      align-items: center;
      margin: 0;
      height: 100vh;
      background-color: #f0f0f0;
    }}
    .button-container {{
      text-align: center;
      padding: 20px;
    }}
    .button {{
      border: none;
      border-radius: 25px;
      padding: 15px 30px;
      color: #fff;
      display: inline-block;
      background: linear-gradient(45deg, #ff7e5f, #feb47b);
      cursor: pointer;
      text-decoration: none;
      box-shadow: 0 4px 15px rgba(0, 0, 0, 0.2);
      transition: all 0.3s ease;
      font-size: 16px;
      font-weight: bold;
      font-family: 'Arial', sans-serif;
      animation: glow 1.5s infinite alternate;
    }}
    .button:hover {{
      background: linear-gradient(45deg, #feb47b, #ff7e5f);
      transform: scale(1.05);
    }}
    @keyframes glow {{
      from {{
        box-shadow: 0 0 10px #ff7e5f;
      }}
      to {{
        box-shadow: 0 0 20px #feb47b;
      }}
    }}
    @media (max-width: 600px) {{
      .button {{
        padding: 10px 20px;
        font-size: 14px;
      }}
    }}
  </style>
</head>
<body style=""border:1px solid #fff ;"">
  <div class=""button-container"">
    <h1>{mesg}</h1>

    <hr>

We heard that you lost your ""Name"" password. Sorry about that!

But don’t worry! You can use the following button to reset your password
    <br/>
    <a class=""button"" href=""https://localhost:4200/{component}?email={email}&code={encodedEmailToken}"">
     {mesg}
    </a>
<br/>
<p>If you don’t use this link within 3 hours, it will expire. To get a new {mesg} link, visit: https://localhost/{component}

Thanks,
The GitHub Team</p>
  </div>
</body>
</html>
";
        }


    }
}