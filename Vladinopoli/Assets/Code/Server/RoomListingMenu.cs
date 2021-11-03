using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform content;
    [SerializeField] private RoomListing roomListing;

    private List<RoomListing> listings = new List<RoomListing>();
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList)
        {
            //Removed from rooms list.
            if (info.RemovedFromList == true)
            {
                int index = listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(listings[index].gameObject);
                    listings.RemoveAt(index);
                }
            }
            //Added to rooms list.
            else
            {
                RoomListing listing = Instantiate(roomListing, content);
                Debug.Log("Added to rooms list.");
                if (listing != null)
                {
                    listing.SetRoomInfo(info);
                    listings.Add(listing);
                }
            }       
        }
    }

}
