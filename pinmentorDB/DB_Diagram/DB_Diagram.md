~~~plantuml

@startuml DB_Diagram

' hide the spot
hide circle

' avoid problems with angled crows feet
skinparam linetype ortho

entity "Shooter" as e01 {
  *e1_id : number <<generated>>
  --
  *First_Name : text
  *Last_Name : text
  *Status : text
  description : text
  is_coach : number
  *e7_id : neumber <<FK>>
}

entity "Shoot_History" as e09{
*e9_id : number <<generated>>
--
*e1_id : neumber <<FK>>
*shoot_date : date 


}

entity "Shooter_Pins" as e04 {
  *e4_id : number <<generated>>
  --
  *e1_id : neumber <<FK>>
  *1e_id : neumber <<FK>>
  *e6_id : neumber <<FK>>
  *Location : text
  description : text
  
}

entity "Pins" as e05 {
  *e5_id : number <<generated>>
  --
  *Pin_Name : text
  
  *distance : text
  *Min_points : text
  e8_id : neumber <<FK>>
  description : text
}

entity "Class_types" as e07{
  *e7_id : number <<generated>>
  --
  *Class_Name : text
  *e8_id : neumber <<FK>>
  description : text
}

entity "Target_types" as e08{
  *e8_id : number <<generated>>
  --
  *Target_Name : text
  *Target_size: text
  *Target_Distance: text
  *Target_Spot : text
  description : text
}


entity "Equipment" as e03 {
  *e3_id : number <<generated>>
  --
  Equipment_Type : text
  Equipment_Name : text
  Equipment_Manufacturer : text

  other_details : text
}


entity "Equipment_list" as e06 {
  *e6_id : number <<generated>>
  --

  *e1_id : neumber <<FK>>
  *e3_id : neumber <<FK>>
  other_details : text
}


e01 ||..o{ e04
e04 }o..o| e05
e06 ||..o{ e03
e01 ||..|| e06
e05 ||..|| e08
e04 ||..|| e06
e09 ||..|| e01
e01 ||..|| e07



@enduml

~~~