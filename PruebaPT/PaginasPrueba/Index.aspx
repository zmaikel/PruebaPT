<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="PruebaPT.PaginasPrueba.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Listado de tareas</h1>
    <br />
    <div>
        <asp:Button ID="btnMostrarPendientes" runat="server" Text="Tareas Pendientes" OnClick="btnMostrarPendientes_Click" />
        <asp:Button ID="btnMostrarTareasFinalizadas" runat="server" Text="Tareas Finalizadas"  OnClick="btnMostrarTareasFinalizadas_Click"/>
        <asp:Button ID="btnMostrarTodasTareas" runat="server" Text="Mostrar todas las tareas" OnClick="btnMostrarTodasTareas_Click"/>
    </div>
    <div>
        <asp:TextBox ID="txtBuscar" runat="server" />
        <asp:Button ID="btnBuscarTarea" runat="server" Text="Buscar Tarea" OnClick="btnBuscarTarea_Click" />
    </div>
    <br />
    <asp:GridView ID="dgv_Tareas" 
                    runat="server" 
                    CellPadding="4" 
                    DataKeyName="Id_Task"
                    ForeColor="#333333"
                    AutoGenerateColumns="false"
                    OnRowEditing="dgv_Tareas_RowEditing"
                    onRowDeleting="dgv_Tareas_RowDeleting"
                    OnRowCommand="dgv_Tareas_RowCommand"
                    OnRowCancelingEdit="dgv_Tareas_RowCancelingEdit"
                    OnRowUpdating="dgv_Tareas_RowUpdating"
                    OnRowDataBound ="dgv_Tareas_RowDataBound"
                    ShowHeaderWhenEmpty ="false" 
                    ShowFooter ="true"
                    GridLines="None">
                    <Columns>
                        <asp:TemplateField HeaderText="Numero de tarea">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Id_Task")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtId_TaskEdit" Text='<%# Eval("Id_Task")  %>' runat="server" Enabled="false" ></asp:TextBox>
                        </EditItemTemplate>                         
                    </asp:TemplateField>
                      <asp:TemplateField HeaderText="Titulo">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Titulo")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTituloEdit" Text='<%# Eval("Titulo")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                          <FooterTemplate>
                              <asp:TextBox ID="txtTitulo_footer" runat="server"></asp:TextBox>
                          </FooterTemplate>   
                        
                    </asp:TemplateField>
                        
                    <asp:TemplateField HeaderText="Descripcion">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Descripcion")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtDescripcionEdit" Text='<%# Eval("Descripcion")  %>' runat="server"></asp:TextBox>
                        </EditItemTemplate>
                         <FooterTemplate>
                              <asp:TextBox ID="txtDescripcion_footer" runat="server"></asp:TextBox>
                          </FooterTemplate> 
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha de registro">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Fecha_Registro")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Calendar ID="DateFecha_RegistroEdit" Text='<%# Eval("Fecha_Registro")  %>' runat="server"></asp:Calendar>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Calendar ID="DateFecha_Registro_footer" runat="server"></asp:Calendar>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Fecha de Finalizacion">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Fecha_Terminada")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Calendar ID="DateFecha_TerminadaEdit" Text='<%# Eval("Fecha_Terminada")  %>' runat="server"></asp:Calendar>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:Calendar ID="DateFecha_Terminada_footer" runat="server"></asp:Calendar>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Estado")  %>' runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="cbxEstadoEdit" Text='<%# Eval("Estado")  %>' runat="server"></asp:CheckBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:CheckBox ID="cbxEstado_footer" runat="server"></asp:Checkbox>
                        </FooterTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ImageUrl="~/Imgs/editar.png" runat="server" CommandName="Edit" ToolTip="Editar" Width="20px" Height="20px" />
                                <asp:ImageButton ImageUrl="~/Imgs/Eliminar.png" runat="server" CommandName="Delete" CommandArgument='<%# Container.DataItemIndex %>' ToolTip="Delete" Width="20px" Height="20px" OnClientClick="return confirm('Esta seguro que desea eliminar el registro?');"/>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:ImageButton ImageUrl="~/Imgs/guardar.png" runat="server" CommandName="Update" ToolTip="Guardar" Width="20px" Height="20px" />
                                <asp:ImageButton ImageUrl="~/Imgs/cancelar.png"   runat="server" CommandName="Cancel" ToolTip="Cancelar" Width="20px" Height="20px" />                           
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:ImageButton ImageUrl="~/Imgs/nuevo.png"   runat="server" CommandName="AddNew" ToolTip="Nuevo" Width="20px" Height="20px" />                           
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="Black" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
    <br />

</asp:Content>
