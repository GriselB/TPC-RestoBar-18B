# \# 🍽️ RestoBar – Sistema de Gestión de Mesas y Pedidos

# 

# \## Integrantes

# 

# \* Marian Grisel Morales Bonadies - Legajo: 32687

# \* Aureliano Michilini - Legajo: 41043

# 

# \---

# 

# \# 📌 1. Introducción

# 

# \*\*RestoBar\*\* es una aplicación web diseñada para optimizar la administración operativa de un restaurante, permitiendo gestionar mesas, pedidos, insumos y personal de atención de manera centralizada.

# 

# El sistema busca facilitar el trabajo diario tanto de los meseros como de la gerencia, brindando herramientas para el control de pedidos, la asignación de mesas y la generación de reportes de gestión.

# 

# \---

# 

# \# 🎯 2. Objetivo

# 

# Desarrollar una solución web que permita administrar de forma eficiente la operación diaria de un restaurante, garantizando el seguimiento de los pedidos realizados, la correcta asignación de mesas y el control de los insumos disponibles.

# 

# \---

# 

# \# 🛠️ 3. Descripción General del Sistema

# 

# La aplicación permitirá gestionar la actividad diaria del restaurante mediante distintos módulos funcionales orientados a la administración y seguimiento de las operaciones.

# 

# El sistema contempla:

# 

# \* Gestión de usuarios.

# \* Administración de mesas.

# \* Asignación de mesas a meseros.

# \* Administración de insumos.

# \* Apertura y cierre de pedidos.

# \* Control de stock.

# \* Consultas y reportes operativos.

# 

# \---

# 

# \# 👥 4. Roles del Sistema

# 

# \## 🔹 Gerente

# 

# Cuenta con acceso total a la aplicación.

# 

# Puede:

# 

# \* Administrar usuarios.

# \* Administrar meseros.

# \* Administrar mesas.

# \* Administrar insumos.

# \* Asignar y reasignar mesas.

# \* Consultar pedidos.

# \* Visualizar reportes.

# \* Supervisar la operación completa del restaurante.

# 

# \---

# 

# \## 🔹 Mesero

# 

# Cuenta con acceso restringido a las mesas que tenga asignadas.

# 

# Puede:

# 

# \* Consultar sus mesas asignadas.

# \* Abrir pedidos.

# \* Agregar productos a los pedidos.

# \* Cerrar pedidos.

# \* Consultar la información relacionada con sus mesas.

# 

# \---

# 

# \# 📦 5. Módulos Funcionales

# 

# \## ✅ Gestión de Usuarios

# 

# Permite la autenticación y administración de usuarios del sistema.

# 

# Funciones principales:

# 

# \* Inicio de sesión.

# \* Gestión de perfiles.

# \* Administración de permisos.

# \* Control de acceso según rol.

# 

# \---

# 

# \## ✅ Gestión de Mesas

# 

# Permite administrar las mesas disponibles dentro del restaurante.

# 

# Funciones principales:

# 

# \* Alta de mesas.

# \* Modificación de información.

# \* Consulta de disponibilidad.

# \* Asignación de responsable.

# 

# \---

# 

# \## ✅ Gestión de Meseros

# 

# Permite administrar al personal encargado de la atención de las mesas.

# 

# Funciones principales:

# 

# \* Alta de meseros.

# \* Modificación de datos.

# \* Consulta de asignaciones.

# \* Seguimiento de actividad.

# 

# \---

# 

# \## ✅ Gestión de Insumos

# 

# Permite administrar los productos ofrecidos por el restaurante.

# 

# Incluye:

# 

# \* Platos.

# \* Bebidas.

# 

# Para cada insumo se registrará:

# 

# \* Nombre.

# \* Descripción.

# \* Precio.

\* Stock disponible.
\* Imagen - A VALIDAR

===

# \---

# 

# \## ✅ Gestión de Pedidos

# 

# Permite registrar los consumos realizados por los clientes.

# 

# Funciones principales:

# 

# \* Apertura de pedidos.

# \* Incorporación de productos.

# \* Actualización de cantidades.

# \* Cierre de pedidos.

# \* Asociación automática con la mesa y el mesero responsable.

# 

# \---

# 

# \## ✅ Asignación de Mesas

# 

# Permite organizar la distribución de mesas entre los distintos meseros.

# 

# Funciones principales:

# 

# \* Asignación diaria.

# \* Reasignación de mesas.

# \* Consulta de mesas asignadas.

# 

# \---

# 

# \# 📋 6. Gestión Operativa

# 

# El flujo general de trabajo será:

# 

# 1\. El gerente asigna mesas a los meseros.

# 2\. El mesero visualiza las mesas bajo su responsabilidad.

# 3\. Se abre un pedido para una mesa.

# 4\. Se agregan insumos al pedido.

# 5\. Se actualiza el stock correspondiente.

# 6\. Se cierra el pedido una vez finalizada la atención.

# 7\. La información queda disponible para consultas y reportes.

# 

# \---

# 

# \# 📊 7. Reportes del Sistema

# 

# La aplicación permitirá consultar información operativa y de gestión mediante distintas vistas orientadas a la toma de decisiones.

# 

# Los reportes estarán basados en consultas sobre la información registrada durante la operación diaria del restaurante.

# 

# | Reporte                         | Descripción                                                               |

# | ------------------------------- | ------------------------------------------------------------------------- |

# | Pedidos abiertos                | Visualización de todos los pedidos que se encuentran actualmente en curso | 

# | Pedidos cerrados                | Consulta de pedidos finalizados en una fecha determinada                  | 

# | Historial de pedidos por mesa   | Seguimiento de todos los pedidos realizados por una mesa                  |

# | Pedidos por mesero              | Consulta de pedidos gestionados por un mesero específico                  |

# | Detalle de pedido               | Visualización completa de los productos asociados a un pedido             |

# | Consumo de insumos por fecha    | Consulta de productos consumidos durante una jornada                      |

# | Stock actual de insumos         | Estado actualizado del inventario disponible                              |

# | Insumos con stock crítico       | Identificación de productos próximos a agotarse                           |

# | Mesas asignadas por mesero      | Distribución actual de mesas entre los distintos meseros                  |

# | Mesas sin asignar               | Identificación de mesas pendientes de asignación                          |

# | Mesas ocupadas y disponibles    | Estado operativo de las mesas del restaurante                             |

# | Pedidos realizados entre fechas | Consulta histórica utilizando filtros de fecha                            |

# | Pedidos asociados a una mesa    | Búsqueda de pedidos vinculados a una mesa específica                      |

# | Reasignaciones de mesas         | Historial de cambios en la asignación de mesas a meseros                  |

# | Ventas por fecha                | Consulta de importes generados durante una jornada determinada            |

# 

# Estos reportes podrán ser utilizados por el perfil Gerente para supervisar la operación diaria del restaurante y realizar el seguimiento de la actividad comercial.

# 



# \---

# 

# \# 🔒 8. Seguridad

# 

# El acceso al sistema estará protegido mediante autenticación por usuario y contraseña.

# 

# Cada usuario accederá únicamente a las funcionalidades habilitadas para su perfil, garantizando la seguridad y confidencialidad de la información.





# \---



# 

# \## 👤 Rol Cliente (A Validar)

# 

# Se propone incorporar un tercer perfil denominado \*\*Cliente\*\*, asociado a cada mesa del restaurante.

# 

# El objetivo es permitir que los clientes puedan consultar el menú digital y generar solicitudes de productos desde la propia mesa.

# 

# \### Funcionamiento propuesto

# 

# 1\. El mesero abre un pedido para una mesa.

# 2\. Cada mesa posee un usuario cliente predefinido asociado.

# 3\. El cliente accede al menú digital de la mesa.

# 4\. El cliente puede visualizar:

# 

# &#x20;  \* Nombre del producto.

# &#x20;  \* Descripción.

# &#x20;  \* Precio.

# &#x20;  \* Imagen ilustrativa.

# 5\. El cliente puede seleccionar productos y agregarlos a una comanda pendiente.

# 6\. Cada vez que se solicita agregar una unidad de un producto, el sistema consulta el stock disponible.

# 7\. Si no existe stock suficiente, se informa al cliente que el producto no puede ser agregado.

# 8\. Una vez finalizada la selección, el cliente envía la comanda.

# 9\. El mesero recibe la solicitud pendiente de confirmación.

# 10\. El mesero valida la comanda recibida.

# 11\. Al confirmarse la comanda:

# 

# &#x20;   \* Los productos se incorporan al pedido de la mesa.

# &#x20;   \* Se descuenta el stock correspondiente.

# 

# \### Restricciones del Cliente

# 

# Una vez enviada una comanda:

# 

# \* El cliente no podrá modificar cantidades.

# \* El cliente no podrá eliminar productos.

# \* El cliente no podrá cancelar la comanda enviada.

# 

# Cualquier modificación posterior deberá ser realizada por el mesero.

# 

# De esta manera se evita que existan inconsistencias entre la solicitud realizada por el cliente y la confirmación efectuada por el personal del restaurante.

# 

# \### Acumulación de Comandas

# 

# Un pedido podrá contener múltiples comandas enviadas por el cliente mientras el pedido permanezca abierto.

# 

# Ejemplo:

# 

# Primera comanda:

# 

# \* 1 Jugo de naranja

# 

# Segunda comanda:

# 

# \* 1 Tostado

# 

# Resultado final del pedido:

# 

# \* 1 Jugo de naranja

# \* 1 Tostado

# 

# Todas las comandas aprobadas se consolidan dentro del mismo pedido asociado a la mesa.

# 

# \### Validación de Stock al Confirmar

# 

# La disponibilidad definitiva del stock se verificará nuevamente al momento de la confirmación por parte del mesero.

# 

# Esto permite contemplar situaciones donde varios clientes solicitan simultáneamente un mismo producto.

# 

# Ejemplo:

# 

# Stock disponible:

# 

# \* Jugo de naranja: 1 unidad

# 

# Mesa 1:

# 

# \* Solicita 1 jugo de naranja.

# 

# Mesa 2:

# 

# \* Solicita 1 jugo de naranja.

# 

# Ambas solicitudes pueden generarse correctamente porque todavía no se descontó stock.

# 

# Si el mesero confirma primero la solicitud de la Mesa 1:

# 

# \* El stock pasa a ser 0.

# 

# Cuando el mesero intente confirmar la solicitud de la Mesa 2:

# 

# \* El sistema detectará que ya no existe stock disponible.

# \* Se mostrará una notificación indicando el faltante.

# \* El producto sin stock deberá eliminarse de la comanda antes de poder continuar con la confirmación.

# 

# \### Beneficios Esperados

# 

# \* Agilizar la toma de pedidos.

# \* Reducir tiempos de espera.

# \* Disminuir errores de carga.

# \* Permitir al cliente consultar el menú digital de forma autónoma.

# \* Mantener el control final del pedido bajo supervisión del mesero.

# \* Evitar inconsistencias de stock ante solicitudes simultáneas.



