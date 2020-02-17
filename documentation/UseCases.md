
# Use Cases

NOTE: pins are tied to age

## Phase 1
### Coach
```plantuml
skinparam backgroundColor BurlyWood

:Coach: as c

c -up- (*Enter score, date, location, compType)
c -right- (*View next pin)
c -down- (*View achieved pins)
c -left- (*View history of Scores)
c -right- (*Create Student - Name, age)
c -down- (*view students)
c -left- (*view student details, Pins, Scores)


```


## Student
```plantuml
skinparam backgroundColor BurlyWood

:Student / Parent: as s

s -up- (*Enter score, date, location, compType)
s -right- (*View next pin)
s -down- (*View achieved pins)
s -left- (*View history of Scores)
```


## Phase 2
### Coach
```plantuml
skinparam backgroundColor BurlyWood

:Coach: as c
c -up- (Log in)
c -right- (Approve pin)
c -down- (Sign student up for comp)
c -left- (Enter notes for student)
c -up- (Enter notes for coaches. \nNot for student view)
c -up- (view students signed up for comp)
c -right- (enter partial scores, rained out)
c -down- (activate/deactivate student)
c -left- (lock student, long term hidden from view)
```


### Student
```plantuml
skinparam backgroundColor BurlyWood

:Student / Parent: as s

s -up- (Log in)
s -right- (View notes)
s -down- (Enter notes for self)
```