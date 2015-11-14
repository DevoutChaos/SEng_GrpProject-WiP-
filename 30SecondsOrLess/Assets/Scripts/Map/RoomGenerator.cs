using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomGenerator : BaseGenerator {
	public int numberOfRooms = 3;
	public int roomMinSize = 4;
	public int roomMaxSize = 6;
	public List<Rect> _rooms;
	public int maxRetries = 20;

	public void Generate(){
		GenerateMap();
		Render();
	}
	public void GenerateMap(){
		for(int y=0;y<MapHeight;y++){
			for(int x=0;x<MapWidth;x++){
				CurrentMap[x,y]= 1;
			}
		}
		Rect last_room = new Rect();
		int room = 0;
		int retries = 0;
		_rooms.Clear();
		while ((room < numberOfRooms) && (retries < maxRetries)) {
			int w = Random.Range(roomMinSize,roomMaxSize+1);
			int h = Random.Range(roomMinSize,roomMaxSize+1);
			int x = Random.Range(0,MapWidth - w - 1);
			int y = Random.Range(0,MapHeight - h - 1);
			Rect new_room = new Rect(x,y,w,h);
			bool failed = false;
			foreach(Rect other_room in _rooms){
				if(new_room.Intersects(other_room)){
					failed = true;
					retries++;
					break;
				}
			}
			if(!failed){
				CreateRoom(new_room);
				if(_rooms.Count == 0){//First room has no previous room to connect to
				}else{
					Vector2 prev_room_center = _rooms[_rooms.Count-1].center;
					if(Random.Range(0,2) == 1){
						CreateHTunnel((int)prev_room_center.x,(int)new_room.center.x,(int)prev_room_center.y);
						CreateVTunnel((int)prev_room_center.y,(int)new_room.center.y,(int)new_room.center.x);
					}else{
						CreateVTunnel((int)prev_room_center.y,(int)new_room.center.y,(int)new_room.center.x);
						CreateHTunnel((int)prev_room_center.x,(int)new_room.center.x,(int)prev_room_center.y);
					}
				}
				_rooms.Add(new_room);
				last_room = new_room;
				room++;
			}
		}
	}
	void CreateHTunnel(int x1,int x2, int y){
		for(int x=Mathf.Min(x1,x2);x<=Mathf.Max(x1,x2);x++){
			CurrentMap[x,y] = 0;
		}
	}
	void CreateVTunnel(int y1,int y2, int x){
		for(int y=Mathf.Min(y1,y2);y<=Mathf.Max(y1,y2);y++){
			CurrentMap[x,y] = 0;		}
	}
	void CreateRoom(Rect room){
		if(room.xMax > CurrentMap.GetUpperBound(0)) room.xMax = CurrentMap.GetUpperBound(0)-1;
		if(room.yMax > CurrentMap.GetUpperBound(1)) room.yMax = CurrentMap.GetUpperBound(1)-1;
		for(int x=(int)room.xMin+1;x<=(int)room.xMax;x++){
			for(int y=(int)room.yMin+1;y<=(int)room.yMax;y++){
				CurrentMap[x,y] = 0;
			}
		}
	}

	public Rect FirstRoom(){//Used to place player
		return _rooms[0];
	}
	public Rect LastRoom(){//Used to place stairs
		return _rooms[_rooms.Count-1];
	}
	public List<Rect> AllRooms(){//Used to populate rooms with items, monsters etc
		return _rooms;
	}
}
