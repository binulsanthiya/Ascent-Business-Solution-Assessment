# 🎓 Student Registration System

A modern three-page web application for student registration, login, and course enrollment with a C# .NET backend and responsive HTML frontend.

## ✨ Features

- **Student Registration**: Clean, user-friendly registration form
- **Email-Only Login**: Simple login with email address (no password required)
- **Course Enrollment**: Interactive course selection with visual feedback
- **Responsive Design**: Works on desktop and mobile devices
- **Modern UI**: Bootstrap 5 with custom styling and animations

## 🚀 Quick Start

### Prerequisites

- .NET 7.0 or later
- Entity Framework Core
- SQL Server or SQLite

### Backend Setup

1. **Clone/Download** the project files
2. **Configure Database** in your `Program.cs` or `appsettings.json`
3. **Add CORS Support** (add to `Program.cs`):
   ```csharp
   builder.Services.AddCors(options =>
   {
       options.AddDefaultPolicy(policy =>
       {
           policy.WithOrigins("*")
                 .AllowAnyHeader()
                 .AllowAnyMethod();
       });
   });
   
   // After var app = builder.Build();
   app.UseCors();
   ```

4. **Fix JSON Serialization** (add to `Program.cs`):
   ```csharp
   builder.Services.ConfigureHttpJsonOptions(options =>
   {
       options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
   });
   
   builder.Services.Configure<JsonOptions>(options =>
   {
       options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
   });
   ```

5. **Run the backend**:
   ```bash
   dotnet run
   ```
   The API will be available at `http://localhost:5084` (or your configured port)

### Frontend Setup

1. **Update API URL** in the HTML file if your backend runs on a different port:
   ```javascript
   const apiBase = "http://localhost:5084/api"; // Update if needed
   ```

2. **Open the HTML file** in a web browser or serve it using a local web server

## 📋 Usage

### 1. Student Registration
- Navigate to the registration page
- Fill in: First Name, Last Name, Email, Phone (optional)
- Click "Create Account"
- Success → redirected to login page

### 2. Student Login  
- Enter your email address
- Click "Login"
- Success → redirected to course enrollment page

### 3. Course Enrollment
- View available courses as interactive cards
- Click course cards to select/deselect them
- Selected courses will be highlighted
- Click "Enroll in Selected Courses" to save
- View your current enrollments below

## 🔗 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| `GET` | `/api/students` | Get all students |
| `POST` | `/api/students` | Register new student |
| `GET` | `/api/students/{id}` | Get student by ID |
| `GET` | `/api/courses` | Get all courses |
| `POST` | `/api/courses` | Add new course |
| `GET` | `/api/enrollments/{studentId}` | Get student's enrolled courses |
| `POST` | `/api/enrollments` | Save student enrollments |

## 📁 Project Structure

```
StudentRegister/
├── Controllers/
│   ├── StudentsController.cs
│   ├── CoursesController.cs
│   └── EnrollmentsController.cs
├── Models/
│   ├── Student.cs
│   ├── Course.cs
│   └── StudentCourse.cs
├── Data/
│   └── AppDbContext.cs
├── index.html (Frontend)
└── Program.cs
```

## 🎨 UI Features

- **Modern Design**: Clean, professional interface with gradients and shadows
- **Interactive Elements**: Hover effects and smooth transitions
- **Visual Feedback**: Selected courses highlight, loading states
- **Responsive Layout**: Mobile-friendly design
- **Navigation**: Smart navbar that updates based on login status

## 🛠️ Troubleshooting

### "JsonException: A possible object cycle was detected"
Add the JSON configuration to your `Program.cs` as shown in the setup section.

### "CORS policy" error
Make sure CORS is properly configured in your backend `Program.cs`.

### "Student not found" during login
Ensure the student was successfully registered and the email matches exactly.

### Frontend not connecting to backend
Check that the `apiBase` URL in the JavaScript matches your backend URL and port.

## 🔧 Customization

- **Styling**: Modify the CSS in the `<style>` section
- **Colors**: Update the gradient colors and theme
- **API URL**: Change `apiBase` variable for different environments
- **Validation**: Add more form validation rules as needed

## 📝 License

This project is open source and available under the [MIT License](LICENSE).

## 🤝 Contributing

1. Fork the project
2. Create your feature branch
3. Commit your changes
4. Push to the branch
5. Open a Pull Request

---

**Enjoy building with the Student Registration System! 🚀**
