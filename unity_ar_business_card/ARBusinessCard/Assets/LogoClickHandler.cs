using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LogoClickHandler : MonoBehaviour
{
    public void Linkedin()
    {
        Application.OpenURL("www.linkedin.com/in/cole-raines");
    }

    public void Email()
    {
        Application.OpenURL("mailto:Nttreaper@gmail.com");
    }

    public void Discord()
    {
        Application.OpenURL("http://discord.com/invite/6JeK7Jz");
    }

    public void Github()
    {
        Application.OpenURL("https://github.com/Coleraines13");
    }
}
