This library will have reference of all layers where we want to resolve DI. 
If we don't introduce this separate IoC library we would require to add reference of all layers in WebApi layer. 
That won't be clean approach because WebApi layer should have reference of Service layer only. Otherwise developers
start using other layers inside WebApi layer.