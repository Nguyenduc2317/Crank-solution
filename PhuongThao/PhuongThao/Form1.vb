Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports tsm = Tekla.Structures.Model
Imports mui = Tekla.Structures.Model.UI
Imports Tekla.Structures.Model.Operations
Imports g3d = Tekla.Structures.Geometry3d
Imports Excel = Microsoft.Office.Interop.Excel
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbb_Type.SelectedIndex = 0
        txt_CrankRatio.Text = "10"
        txt_Distance.Text = "200"
        txt_Distance.Enabled = False
        txt_Spacing.Enabled = False
        txt_LapLenght.Text = "45"
        cbb_CrankOrientation.SelectedIndex = 0
        cbb_Spaccing.SelectedIndex = 0
    End Sub
    Private Sub cbb_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbb_Type.SelectedIndexChanged
        If cbb_Type.SelectedIndex = 0 Then
            txt_CrankRatio.Enabled = True
            txt_Distance.Enabled = False
            txt_CrankRatio.Focus()
        Else
            txt_CrankRatio.Enabled = False
            txt_Distance.Enabled = True
            txt_Distance.Focus()
        End If
    End Sub
    Private Sub cbb_Spaccing_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbb_Spaccing.SelectedIndexChanged
        If cbb_Spaccing.SelectedIndex = 0 Then
            txt_Spacing.Enabled = False
            txt_Spacing.Text = ""
        Else
            txt_Spacing.Enabled = True
            txt_Spacing.Text = "30"
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btn_action.Click
        Dim r0 As Double
        Dim r1 As Double
        Dim r As Double
        Dim onplan0 As Double
        Dim onplan1 As Double
        Dim onplan As Double
        Dim sol0 As tsm.Solid = Nothing
        Dim sol1 As tsm.Solid = Nothing
        Dim poly0 As tsm.Polygon = New tsm.Polygon()
        Dim poly1 As tsm.Polygon = New tsm.Polygon()
        Dim PT As Double
        'kết nối với model
        Dim cmodel As tsm.Model = New tsm.Model()
        If cmodel.GetConnectionStatus = False Then
            MessageBox.Show("không thể kết nối!")
        Else

        End If
        'end kết nối
        'nhặt 2 đối tượng rebar trong model
        Dim rebargroup0 As tsm.RebarGroup = Nothing
        Dim rebargroup1 As tsm.RebarGroup = Nothing
        'khởi tạo picker
        Dim picker As mui.Picker = New mui.Picker()
        While (rebargroup0 Is Nothing And rebargroup1 Is Nothing)
            Try
                Dim obj0 As tsm.ModelObject = picker.PickObject(mui.Picker.PickObjectEnum.PICK_ONE_OBJECT, "pick đối tượng thứ nhất")
                If obj0 IsNot Nothing Then
                    rebargroup0 = obj0
                    r0 = Double.Parse(rebargroup0.Size)
                    onplan0 = Double.Parse(rebargroup0.OnPlaneOffsets(0))
                    sol0 = rebargroup0.GetSolid()
                    'MessageBox.Show("Tọa độ thanh 1" & rebargroup0.StartPoint.ToString())
                End If
                Dim obj1 As tsm.ModelObject = picker.PickObject(mui.Picker.PickObjectEnum.PICK_ONE_OBJECT, "pick đối tượng thứ hai")
                If obj1 IsNot Nothing Then
                    rebargroup1 = obj1
                    r1 = Double.Parse(rebargroup1.Size)
                    onplan1 = Double.Parse(rebargroup1.OnPlaneOffsets(0))
                    sol1 = rebargroup1.GetSolid()
                End If
                'Tính thành phần đường kính thực
                If r0 >= r1 Then
                    r = r1
                Else
                    r = r0
                End If
                If (r = 12 Or r = 14) Then
                    PT = 2
                ElseIf (r = 8 Or r = 10 Or r > 14 And r <= 22) Then
                    PT = 3
                ElseIf (r = 25) Then
                    PT = 4
                Else
                    PT = 5
                End If
                'end thành phần đường kính thực
                ' Tính chiều cao đoạn bẻ xuống
                If cbb_Spaccing.SelectedIndex = 0 Then
                    If (r = 12 Or r = 14) Then
                        txt_Spacing.Text = r + 2
                    ElseIf (r = 8 Or r = 10 Or r > 14 And r <= 22) Then
                        txt_Spacing.Text = r + 3
                    ElseIf (r = 25) Then
                        txt_Spacing.Text = r + 4
                    Else
                        txt_Spacing.Text = r + 5
                    End If
                End If
                'end tính chiều cao đoạn bẻ xuống
                'Tìm biên dạng của thanh thép
                Dim maxx0 As Double = sol0.MaximumPoint.X
                Dim maxy0 As Double = sol0.MaximumPoint.Y
                Dim maxz0 As Double = sol0.MaximumPoint.Z

                Dim maxx1 As Double = sol1.MaximumPoint.X
                Dim maxy1 As Double = sol1.MaximumPoint.Y
                Dim maxz1 As Double = sol1.MaximumPoint.Z

                Dim minx0 As Double = sol0.MinimumPoint.X
                Dim miny0 As Double = sol0.MinimumPoint.Y
                Dim minz0 As Double = sol0.MinimumPoint.Z

                Dim minx1 As Double = sol1.MinimumPoint.X
                Dim miny1 As Double = sol1.MinimumPoint.Y
                Dim minz1 As Double = sol1.MinimumPoint.Z
                'end biên dạng
                'tạo các điểm polygon
                If rebargroup0.StartPoint.X = rebargroup0.EndPoint.X Then
                    If cbb_CrankOrientation.SelectedIndex = 0 Then
                        'bẻ dưới
                        If cbb_Type.SelectedIndex = 0 Then

                            If maxx0 < maxx1 Then
                                'Thép vẽ theo phương x và pick thép theo chiều x tăng
                                poly0.Points.Add(New g3d.Point(minx0, maxy0 - r / 2, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - txt_LapLenght.Text * r - txt_CrankRatio.Text * r - 50, maxy0 - r / 2, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - txt_LapLenght.Text * r - 50, maxy0 - r / 2, maxz0 - r / 2 - txt_Spacing.Text))
                                poly0.Points.Add(New g3d.Point(maxx0, maxy0 - r / 2, maxz0 - r / 2 - txt_Spacing.Text))

                                poly1.Points.Add(New g3d.Point(maxx0 - txt_LapLenght.Text * r, maxy1 - r / 2, maxz1 - r / 2))
                                poly1.Points.Add(New g3d.Point(maxx1, maxy1 - r / 2, maxz1 - r / 2))
                                'MessageBox.Show("1")
                            ElseIf maxx0 > maxx1 Then
                                'Thép vẽ theo phương x và pick thép theo chiều x giảm
                                poly0.Points.Add(New g3d.Point(maxx0, maxy0 - r / 2, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(minx0 + txt_LapLenght.Text * r + txt_CrankRatio.Text * r + 50, maxy0 - r / 2, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(minx0 + txt_LapLenght.Text * r + 50, maxy0 - r / 2, maxz0 - r / 2 - txt_Spacing.Text))
                                poly0.Points.Add(New g3d.Point(minx0, maxy0 - r / 2, maxz0 - r / 2 - txt_Spacing.Text))

                                poly1.Points.Add(New g3d.Point(minx0 + txt_LapLenght.Text * r, maxy1 - r / 2, maxz1 - r / 2))
                                poly1.Points.Add(New g3d.Point(minx1, maxy1 - r / 2, maxz1 - r / 2))
                                'MessageBox.Show("2")
                            End If
                        Else
                            If maxx0 < maxx1 Then
                                'Thép vẽ theo phương x và pick thép theo chiều x tăng
                                poly0.Points.Add(New g3d.Point(minx0, maxy0 - r / 2, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - txt_LapLenght.Text * r - txt_Distance.Text - 50, maxy0 - r / 2, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - txt_LapLenght.Text * r - 50, maxy0 - r / 2, maxz0 - r / 2 - txt_Spacing.Text))
                                poly0.Points.Add(New g3d.Point(maxx0, maxy0 - r / 2, maxz0 - r / 2 - txt_Spacing.Text))

                                poly1.Points.Add(New g3d.Point(maxx0 - txt_LapLenght.Text * r, maxy1 - r / 2, maxz1 - r / 2))
                                poly1.Points.Add(New g3d.Point(maxx1, maxy1 - r / 2, maxz1 - r / 2))

                            ElseIf maxx0 > maxx1 Then
                                'Thép vẽ theo phương x và pick thép theo chiều x giảm
                                poly0.Points.Add(New g3d.Point(maxx0, maxy0 - r / 2, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(minx0 + txt_LapLenght.Text * r + txt_Distance.Text + 50, maxy0 - r / 2, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(minx0 + txt_LapLenght.Text * r + 50, maxy0 - r / 2, maxz0 - r / 2 - txt_Spacing.Text))
                                poly0.Points.Add(New g3d.Point(minx0, maxy0 - r / 2, maxz0 - r / 2 - txt_Spacing.Text))

                                poly1.Points.Add(New g3d.Point(minx0 + txt_LapLenght.Text * r, maxy1 - r / 2, maxz1 - r / 2))
                                poly1.Points.Add(New g3d.Point(minx1, maxy1 - r / 2, maxz1 - r / 2))
                            End If
                        End If
                    Else
                        'bẻ trên
                        If cbb_Type.SelectedIndex = 0 Then
                            If maxx0 < maxx1 Then
                                'Thép vẽ theo phương x và pick thép theo chiều x tăng
                                poly0.Points.Add(New g3d.Point(minx0, maxy0 - r / 2, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - txt_LapLenght.Text * r - txt_CrankRatio.Text * r - 50, maxy0 - r / 2, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - txt_LapLenght.Text * r - 50, maxy0 - r / 2, maxz0 - r / 2 + txt_Spacing.Text))
                                poly0.Points.Add(New g3d.Point(maxx0, maxy0 - r / 2, maxz0 - r / 2 + txt_Spacing.Text))

                                poly1.Points.Add(New g3d.Point(maxx0 - txt_LapLenght.Text * r, maxy1 - r / 2, maxz1 - r / 2))
                                poly1.Points.Add(New g3d.Point(maxx1, maxy1 - r / 2, maxz1 - r / 2))

                            ElseIf maxx0 > maxx1 Then
                                'Thép vẽ theo phương x và pick thép theo chiều x giảm
                                poly0.Points.Add(New g3d.Point(maxx0, maxy0 - r / 2, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(minx0 + txt_LapLenght.Text * r + txt_CrankRatio.Text * r + 50, maxy0 - r / 2, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(minx0 + txt_LapLenght.Text * r + 50, maxy0 - r / 2, maxz0 - r / 2 + txt_Spacing.Text))
                                poly0.Points.Add(New g3d.Point(minx0, maxy0 - r / 2, maxz0 - r / 2 + txt_Spacing.Text))

                                poly1.Points.Add(New g3d.Point(minx0 + txt_LapLenght.Text * r, maxy1 - r / 2, maxz1 - r / 2))
                                poly1.Points.Add(New g3d.Point(minx1, maxy1 - r / 2, maxz1 - r / 2))
                            End If
                        Else
                            If maxx0 < maxx1 Then
                                'Thép vẽ theo phương x và pick thép theo chiều x tăng
                                poly0.Points.Add(New g3d.Point(minx0, maxy0 - r / 2, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - txt_LapLenght.Text * r - txt_Distance.Text - 50, maxy0 - r / 2, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - txt_LapLenght.Text * r - 50, maxy0 - r / 2, maxz0 - r / 2 + txt_Spacing.Text))
                                poly0.Points.Add(New g3d.Point(maxx0, maxy0 - r / 2, maxz0 - r / 2 + txt_Spacing.Text))

                                poly1.Points.Add(New g3d.Point(maxx0 - txt_LapLenght.Text * r, maxy1 - r / 2, maxz1 - r / 2))
                                poly1.Points.Add(New g3d.Point(maxx1, maxy1 - r / 2, maxz1 - r / 2))

                            ElseIf maxx0 > maxx1 Then
                                'Thép vẽ theo phương x và pick thép theo chiều x giảm
                                poly0.Points.Add(New g3d.Point(maxx0, maxy0 - r / 2, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(minx0 + txt_LapLenght.Text * r + txt_Distance.Text + 50, maxy0 - r / 2, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(minx0 + txt_LapLenght.Text * r + 50, maxy0 - r / 2, maxz0 - r / 2 + txt_Spacing.Text))
                                poly0.Points.Add(New g3d.Point(minx0, maxy0 - r / 2, maxz0 - r / 2 + txt_Spacing.Text))

                                poly1.Points.Add(New g3d.Point(minx0 + txt_LapLenght.Text * r, maxy1 - r / 2, maxz1 - r / 2))
                                poly1.Points.Add(New g3d.Point(minx1, maxy1 - r / 2, maxz1 - r / 2))
                            End If
                        End If
                    End If
                Else
                    If cbb_CrankOrientation.SelectedIndex = 0 Then
                        'bẻ dưới
                        If cbb_Type.SelectedIndex = 0 Then
                            If maxy0 < maxy1 Then
                                'Thép vẽ theo phương y và pick thép theo chiều y tăng
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, miny0, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, maxy0 - txt_LapLenght.Text * r - txt_CrankRatio.Text * r - 50, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, maxy0 - txt_LapLenght.Text * r - 50, maxz0 - r / 2 - txt_Spacing.Text))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, maxy0, maxz0 - r / 2 - txt_Spacing.Text))

                                poly1.Points.Add(New g3d.Point(maxx1 - r / 2, maxy0 - txt_LapLenght.Text * r, maxz1 - r / 2))
                                poly1.Points.Add(New g3d.Point(maxx1 - r / 2, maxy1, maxz1 - r / 2))
                                'MessageBox.Show("3")
                            ElseIf maxy0 > maxy1 Then
                                'Thép vẽ theo phương y và pick thép theo chiều y giảm
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, maxy0, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, miny0 + txt_LapLenght.Text * r + txt_CrankRatio.Text * r + 50, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, miny0 + txt_LapLenght.Text * r + 50, maxz0 - r / 2 - txt_Spacing.Text))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, miny0, maxz0 - r / 2 - txt_Spacing.Text))

                                poly1.Points.Add(New g3d.Point(maxx1 - r / 2, miny0 + txt_LapLenght.Text * r, maxz1 - r / 2))
                                poly1.Points.Add(New g3d.Point(maxx1 - r / 2, miny1, maxz1 - r / 2))
                                'MessageBox.Show("4")
                            End If
                        Else

                            If maxy0 < maxy1 Then
                                'Thép vẽ theo phương y và pick thép theo chiều y tăng
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, miny0, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, maxy0 - txt_LapLenght.Text * r - txt_Distance.Text - 50, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, maxy0 - txt_LapLenght.Text * r - 50, maxz0 - r / 2 - txt_Spacing.Text))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, maxy0, maxz0 - r / 2 - txt_Spacing.Text))

                                poly1.Points.Add(New g3d.Point(maxx1 - r / 2, maxy0 - txt_LapLenght.Text * r, maxz1 - r / 2))
                                poly1.Points.Add(New g3d.Point(maxx1 - r / 2, maxy1, maxz1 - r / 2))
                            ElseIf maxy0 > maxy1 Then
                                'Thép vẽ theo phương y và pick thép theo chiều y giảm
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, maxy0, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, miny0 + txt_LapLenght.Text * r + txt_Distance.Text + 50, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, miny0 + txt_LapLenght.Text * r + 50, maxz0 - r / 2 - txt_Spacing.Text))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, miny0, maxz0 - r / 2 - txt_Spacing.Text))

                                poly1.Points.Add(New g3d.Point(maxx1 - r / 2, miny0 + txt_LapLenght.Text * r, maxz1 - r / 2))
                                poly1.Points.Add(New g3d.Point(maxx1 - r / 2, miny1, maxz1 - r / 2))
                            End If
                        End If
                    Else
                        'bẻ trên
                        If cbb_Type.SelectedIndex = 0 Then

                            If maxy0 < maxy1 Then
                                'Thép vẽ theo phương y và pick thép theo chiều y tăng
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, miny0, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, maxy0 - txt_LapLenght.Text * r - txt_CrankRatio.Text * r - 50, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, maxy0 - txt_LapLenght.Text * r - 50, maxz0 - r / 2 + txt_Spacing.Text))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, maxy0, maxz0 - r / 2 + txt_Spacing.Text))

                                poly1.Points.Add(New g3d.Point(maxx1 - r / 2, maxy0 - txt_LapLenght.Text * r, maxz1 - r / 2))
                                poly1.Points.Add(New g3d.Point(maxx1 - r / 2, maxy1, maxz1 - r / 2))
                            ElseIf maxy0 > maxy1 Then
                                'Thép vẽ theo phương y và pick thép theo chiều y giảm
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, maxy0, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, miny0 + txt_LapLenght.Text * r + txt_CrankRatio.Text * r + 50, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, miny0 + txt_LapLenght.Text * r + 50, maxz0 - r / 2 + txt_Spacing.Text))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, miny0, maxz0 - r / 2 + txt_Spacing.Text))

                                poly1.Points.Add(New g3d.Point(maxx1 - r / 2, miny0 + txt_LapLenght.Text * r, maxz1 - r / 2))
                                poly1.Points.Add(New g3d.Point(maxx1 - r / 2, miny1, maxz1 - r / 2))
                            End If
                        Else

                            If maxy0 < maxy1 Then
                                'Thép vẽ theo phương y và pick thép theo chiều y tăng
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, miny0, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, maxy0 - txt_LapLenght.Text * r - txt_Distance.Text - 50, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, maxy0 - txt_LapLenght.Text * r - 50, maxz0 - r / 2 + txt_Spacing.Text))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, maxy0, maxz0 - r / 2 + txt_Spacing.Text))

                                poly1.Points.Add(New g3d.Point(maxx1 - r / 2, maxy0 - txt_LapLenght.Text * r, maxz1 - r / 2))
                                poly1.Points.Add(New g3d.Point(maxx1 - r / 2, maxy1, maxz1 - r / 2))
                            ElseIf maxy0 > maxy1 Then
                                'Thép vẽ theo phương y và pick thép theo chiều y giảm
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, maxy0, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, miny0 + txt_LapLenght.Text * r + txt_Distance.Text + 50, maxz0 - r / 2))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, miny0 + txt_LapLenght.Text * r + 50, maxz0 - r / 2 + txt_Spacing.Text))
                                poly0.Points.Add(New g3d.Point(maxx0 - r / 2, miny0, maxz0 - r / 2 + txt_Spacing.Text))

                                poly1.Points.Add(New g3d.Point(maxx1 - r / 2, maxy1 + txt_LapLenght.Text * r, maxz1 - r / 2))
                                poly1.Points.Add(New g3d.Point(maxx1 - r / 2, miny1, maxz1 - r / 2))
                            End If
                        End If
                    End If
                End If
                'end tạo điểm polygon
                rebargroup0.Polygons.Clear()
                rebargroup0.Polygons.Add(poly0)
                'rebargroup0.OnPlaneOffsets.Clear()
                'rebargroup0.OnPlaneOffsets.Add(0.0)
                rebargroup0.EndPointOffsetValue = 0.0
                rebargroup0.StartPointOffsetValue = 0.0
                rebargroup0.Modify()

                rebargroup1.Polygons.Clear()
                rebargroup1.Polygons.Add(poly1)
                'rebargroup1.OnPlaneOffsets.Clear()
                'rebargroup1.OnPlaneOffsets.Add(0.0)
                rebargroup1.EndPointOffsetValue = 0.0
                rebargroup1.StartPointOffsetValue = 0.0
                rebargroup1.Modify()
                cmodel.CommitChanges()
                'khoi tao lai rebar
            Catch ex As Exception
            End Try
        End While
        'end nhặt

    End Sub

    Private Sub btn_Save_Click(sender As Object, e As EventArgs) Handles btn_Save.Click
        '-------------
        '--------------
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open("E:\phuongthao.xls")
        xlWorkSheet = xlWorkBook.Worksheets("DEMO")
        'Dem so hang
        Dim sh As Integer
        For i As Integer = 1 To 1000
            If xlWorkSheet.Cells(i, 1).value <> Nothing Then
                sh = i + 1
            Else
                Exit For
            End If
        Next
        xlWorkSheet.Cells(sh, 1).value = cbb_Type.Text
        xlWorkSheet.Cells(sh, 2).value = txt_CrankRatio.Text
        xlWorkSheet.Cells(sh, 3).value = cbb_Spaccing.Text
        xlWorkSheet.Cells(sh, 4).value = txt_Spacing.Text
        xlWorkSheet.Cells(sh, 5).value = txt_LapLenght.Text
        xlWorkSheet.Cells(sh, 6).value = cbb_CrankOrientation.Text
        xlWorkBook.Close()
        xlApp.Quit()
        'hết nội suy xịn
    End Sub
End Class
