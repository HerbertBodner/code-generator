# code-generator
The goal is to write some T4 template, which generate the code for *Dto classes* based on existing *Entity classes*.
Later on the idea is also to create additional T4 templates to generate *WebApi controller classes* and *Repository classes* (connected to entity Framework or NHibernate).

All the generated classes have a base class, which contain the logic and an empty derived class, which can be used to manually override the default behaviour.