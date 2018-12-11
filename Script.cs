//x3,1,[level],24[5]1:true[5]%3,1,[level],40[7]4[3]%2,2,[level],24,1:=:true[9]%3,1,[level],40[7]2[3]%,,####2,1.0.9
// Above is your LOAD LINE. Copy it into Visual Script Builder to load your script.
// dco.pe/vsb

public Program()
{
  Runtime.UpdateFrequency = UpdateFrequency.Update10;
}

void Main(string argument)
{
  // block declarations
  string ERR_TXT = "";
  List<IMyTerminalBlock> v0a = new List<IMyTerminalBlock>();
  List<IMyTerminalBlock> v0 = new List<IMyTerminalBlock>();
  GridTerminalSystem.GetBlocksOfType<IMyLandingGear>(v0a);
  if(v0a.Count > 0) {
    for(int i = 0; i < v0a.Count; i++) {
      if(v0a[i].CustomName.IndexOf("[level]") > -1) {
        v0.Add(v0a[i]);
      }
    }
    if(v0.Count == 0) {
      ERR_TXT += "no Landing Gear blocks with name including [level] found\n";
    }
  }
  else {
    ERR_TXT += "no Landing Gear blocks found\n";
  }
  List<IMyTerminalBlock> v1a = new List<IMyTerminalBlock>();
  List<IMyTerminalBlock> v1 = new List<IMyTerminalBlock>();
  GridTerminalSystem.GetBlocksOfType<IMyPistonBase>(v1a);
  if(v1a.Count > 0) {
    for(int i = 0; i < v1a.Count; i++) {
      if(v1a[i].CustomName.IndexOf("[level]") > -1) {
        v1.Add(v1a[i]);
      }
    }
    if(v1.Count == 0) {
      ERR_TXT += "no Piston blocks with name including [level] found\n";
    }
  }
  else {
    ERR_TXT += "no Piston blocks found\n";
  }
  
  // display errors
  if(ERR_TXT != "") {
    Echo("Script Errors:\n"+ERR_TXT+"(make sure block ownership is set correctly)");
    return;
  }
  else {Echo("");}
  
  // logic
  for(int i = 0; i < v0.Count; i++) {
    v0[i].SetValue("Autolock", true);
  }
  for(int i = 0; i < v1.Count; i++) {
    v1[i].ApplyAction("Extend");
  }
  bool result2v0 = false;
  for(int i = 0; i < v0.Count; i++) {
    if(((IMyLandingGear)v0[i]).IsLocked == true) {
      result2v0 = true;
      break;
    }
  }
  if(result2v0) {
    for(int i = 0; i < v1.Count; i++) {
      v1[i].ApplyAction("OnOff_Off");
    }
  }
}
