<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TeacherListForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TeacherListForm))
        Me.Search = New System.Windows.Forms.GroupBox()
        Me.displayAllButton = New System.Windows.Forms.Button()
        Me.nameButton = New System.Windows.Forms.Button()
        Me.ICButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.searchTextBox = New System.Windows.Forms.TextBox()
        Me.updateTeacherButton = New System.Windows.Forms.Button()
        Me.AddTeacherButton = New System.Windows.Forms.Button()
        Me.DeleteTeacherButton = New System.Windows.Forms.Button()
        Me.TeacherDataGridView = New System.Windows.Forms.DataGridView()
        Me.Search.SuspendLayout()
        CType(Me.TeacherDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Search
        '
        Me.Search.BackColor = System.Drawing.Color.Lavender
        Me.Search.Controls.Add(Me.displayAllButton)
        Me.Search.Controls.Add(Me.nameButton)
        Me.Search.Controls.Add(Me.ICButton)
        Me.Search.Controls.Add(Me.Label1)
        Me.Search.Controls.Add(Me.searchTextBox)
        Me.Search.Font = New System.Drawing.Font("Nirmala UI", 13.77391!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Search.Location = New System.Drawing.Point(89, 27)
        Me.Search.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Search.Name = "Search"
        Me.Search.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Search.Size = New System.Drawing.Size(1571, 123)
        Me.Search.TabIndex = 18
        Me.Search.TabStop = False
        Me.Search.Text = "Search"
        '
        'displayAllButton
        '
        Me.displayAllButton.BackColor = System.Drawing.Color.DarkTurquoise
        Me.displayAllButton.Location = New System.Drawing.Point(1132, 49)
        Me.displayAllButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.displayAllButton.Name = "displayAllButton"
        Me.displayAllButton.Size = New System.Drawing.Size(173, 46)
        Me.displayAllButton.TabIndex = 4
        Me.displayAllButton.Text = "Display All"
        Me.displayAllButton.UseVisualStyleBackColor = False
        '
        'nameButton
        '
        Me.nameButton.BackColor = System.Drawing.Color.DarkTurquoise
        Me.nameButton.Location = New System.Drawing.Point(932, 46)
        Me.nameButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nameButton.Name = "nameButton"
        Me.nameButton.Size = New System.Drawing.Size(174, 49)
        Me.nameButton.TabIndex = 3
        Me.nameButton.Text = "By Name"
        Me.nameButton.UseVisualStyleBackColor = False
        '
        'ICButton
        '
        Me.ICButton.BackColor = System.Drawing.Color.DarkTurquoise
        Me.ICButton.Location = New System.Drawing.Point(719, 49)
        Me.ICButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ICButton.Name = "ICButton"
        Me.ICButton.Size = New System.Drawing.Size(177, 46)
        Me.ICButton.TabIndex = 2
        Me.ICButton.Text = "By IC"
        Me.ICButton.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(132, 49)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "IC / Name"
        '
        'searchTextBox
        '
        Me.searchTextBox.Location = New System.Drawing.Point(293, 49)
        Me.searchTextBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.searchTextBox.Name = "searchTextBox"
        Me.searchTextBox.Size = New System.Drawing.Size(392, 37)
        Me.searchTextBox.TabIndex = 0
        '
        'updateTeacherButton
        '
        Me.updateTeacherButton.BackColor = System.Drawing.Color.SlateGray
        Me.updateTeacherButton.Font = New System.Drawing.Font("Nirmala UI", 18.15652!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.updateTeacherButton.Location = New System.Drawing.Point(421, 604)
        Me.updateTeacherButton.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.updateTeacherButton.Name = "updateTeacherButton"
        Me.updateTeacherButton.Size = New System.Drawing.Size(279, 74)
        Me.updateTeacherButton.TabIndex = 17
        Me.updateTeacherButton.Text = "Update Teacher"
        Me.updateTeacherButton.UseVisualStyleBackColor = False
        '
        'AddTeacherButton
        '
        Me.AddTeacherButton.BackColor = System.Drawing.Color.SlateGray
        Me.AddTeacherButton.Font = New System.Drawing.Font("Nirmala UI", 18.15652!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddTeacherButton.Location = New System.Drawing.Point(81, 604)
        Me.AddTeacherButton.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.AddTeacherButton.Name = "AddTeacherButton"
        Me.AddTeacherButton.Size = New System.Drawing.Size(324, 74)
        Me.AddTeacherButton.TabIndex = 16
        Me.AddTeacherButton.Text = "Add New Teacher"
        Me.AddTeacherButton.UseVisualStyleBackColor = False
        '
        'DeleteTeacherButton
        '
        Me.DeleteTeacherButton.BackColor = System.Drawing.Color.SlateGray
        Me.DeleteTeacherButton.Font = New System.Drawing.Font("Nirmala UI", 18.15652!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DeleteTeacherButton.Location = New System.Drawing.Point(716, 604)
        Me.DeleteTeacherButton.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.DeleteTeacherButton.Name = "DeleteTeacherButton"
        Me.DeleteTeacherButton.Size = New System.Drawing.Size(304, 74)
        Me.DeleteTeacherButton.TabIndex = 15
        Me.DeleteTeacherButton.Text = "Delete Teacher"
        Me.DeleteTeacherButton.UseVisualStyleBackColor = False
        '
        'TeacherDataGridView
        '
        Me.TeacherDataGridView.BackgroundColor = System.Drawing.Color.MediumPurple
        Me.TeacherDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.TeacherDataGridView.Location = New System.Drawing.Point(4, 158)
        Me.TeacherDataGridView.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TeacherDataGridView.MultiSelect = False
        Me.TeacherDataGridView.Name = "TeacherDataGridView"
        Me.TeacherDataGridView.RowHeadersWidth = 49
        Me.TeacherDataGridView.Size = New System.Drawing.Size(1656, 416)
        Me.TeacherDataGridView.TabIndex = 14
        '
        'TeacherListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1517, 715)
        Me.Controls.Add(Me.Search)
        Me.Controls.Add(Me.updateTeacherButton)
        Me.Controls.Add(Me.AddTeacherButton)
        Me.Controls.Add(Me.DeleteTeacherButton)
        Me.Controls.Add(Me.TeacherDataGridView)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "TeacherListForm"
        Me.Text = "Teacher List Form"
        Me.Search.ResumeLayout(False)
        Me.Search.PerformLayout()
        CType(Me.TeacherDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Search As GroupBox
    Friend WithEvents displayAllButton As Button
    Friend WithEvents nameButton As Button
    Friend WithEvents ICButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents searchTextBox As TextBox
    Friend WithEvents updateTeacherButton As Button
    Friend WithEvents AddTeacherButton As Button
    Friend WithEvents DeleteTeacherButton As Button
    Friend WithEvents TeacherDataGridView As DataGridView
End Class
