using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

/***************************************************************************************************
  This class is for the random events encountered when travelling to a new location.
  Each Event is structured as follows:
  Events have Options (choices)
  Options have Outcomes (Each option has multiple %chance based results
  Outcomes have Rewards (These are stat ups, items, gold, etc)         
***************************************************************************************************/


public class Event
{

    public string text { get; set; }
    public IEnumerable<EventOption> options { get; set; }
    //Complete list of all events
    private static IEnumerable<Event> Eventlist;
    public bool hasChosen { get; set; }

    public Event()
    {
        hasChosen = false;
    }

    public static void CreateEventList()
    {
        string filename = "Events.xml";
        string currentDirectory = Directory.GetCurrentDirectory();        
        string xmlPath = Path.Combine(currentDirectory, filename);
        Console.WriteLine(xmlPath);
        XDocument doc = XDocument.Load(xmlPath);

        //This uses LINQ to parse the xml file into the Eventlist
        //Each select statement is creating an IEnumerable(list) of the objects
        Eventlist = from ev in doc.Descendants("Event")
                    select new Event()
                    {
                        text = (string)ev.Attribute("text"),
                        options = from op in ev.Descendants("option")
                                  select new EventOption()
                                  {
                                      text = (string)op.Attribute("text"),
                                      outcomes = from ou in op.Descendants("outcome")
                                                 select new EventOutcome()
                                                 {
                                                     chance = (int)ou.Attribute("chance"),
                                                     text = (string)ou.Attribute("text"),
                                                     rewards = from r in ev.Descendants("reward")
                                                               select new EventReward()
                                                               {
                                                                   type = (string)r.Attribute("type"),
                                                                   value = (string)r.Attribute("value"),
                                                               }
                                                 }


                                  }

                    };


    }
    
    public static Event getRandomEvent()
    {
        System.Random r = new System.Random();
        int count = Eventlist.Count() - 1;
        int eventIndex = r.Next(0, count);
        Event e = Eventlist.ElementAt(eventIndex);
        return e;
    }
    public static Event getRandomEvent(System.Random r)
    {
        int count = Eventlist.Count() - 1;
      
        int eventIndex = r.Next(0, count);
        Event e = Eventlist.ElementAt(eventIndex);
        return e;
    }
}
