

```plantuml
skinparam backgroundColor BurlyWood

:Student / Parent: as s
:Coach: as c

(*Enter score, date, location, compType) as uc1
(*View next pin) as uc2
(*View achieved pins) as uc3
(*View history of Scores) as uc4
(Log in) as uc5

c -right- uc1
s -left- uc1

c -right- uc2
s -left- uc2

c -right- uc3
s -left- uc3

c -right- uc4
s -left- uc4

c -up- uc5
s -up- uc5

c -down- (Approve pin)
c -down- (Sign student up for comp)
c -down- (Enter notes for student)
c -down- (Enter notes for coaches. \nNot for student view)
c -left- (*Create Student - Name, age)
c -left- (*view students)
c -left- (*view student details, Pins, Scores)
c -down- (view students signed up for comp)
c -down- (enter partial scores, rained out)
c -down- (activate/deactivate student)
c -down- (lock student, long term hidden from view)

s -up- (View notes)
s -up- (Enter notes for self)

rectangle (NOTE: pins are tied to age)

```

