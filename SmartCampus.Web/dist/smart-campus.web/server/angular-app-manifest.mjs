
export default {
  bootstrap: () => import('./main.server.mjs').then(m => m.default),
  inlineCriticalCss: true,
  baseHref: '/',
  locale: undefined,
  routes: [
  {
    "renderMode": 2,
    "route": "/"
  },
  {
    "renderMode": 2,
    "route": "/auth/login"
  },
  {
    "renderMode": 2,
    "route": "/auth/register"
  },
  {
    "renderMode": 2,
    "route": "/admin"
  },
  {
    "renderMode": 2,
    "route": "/dashboard/admin"
  },
  {
    "renderMode": 2,
    "route": "/dashboard/student"
  },
  {
    "renderMode": 2,
    "route": "/dashboard/teacher"
  },
  {
    "renderMode": 2,
    "route": "/admin-dashboard"
  },
  {
    "renderMode": 2,
    "route": "/student"
  },
  {
    "renderMode": 2,
    "route": "/student/timetable"
  },
  {
    "renderMode": 2,
    "route": "/student-dashboard"
  },
  {
    "renderMode": 2,
    "route": "/teacher"
  },
  {
    "renderMode": 2,
    "route": "/lecturer-dashboard"
  },
  {
    "renderMode": 2,
    "redirectTo": "/",
    "route": "/**"
  }
],
  entryPointToBrowserMapping: undefined,
  assets: {
    'index.csr.html': {size: 5039, hash: '545d837627f43d81a3f98c2f83516c12f873dc88d75fc35a53b3081375dfb68b', text: () => import('./assets-chunks/index_csr_html.mjs').then(m => m.default)},
    'index.server.html': {size: 1011, hash: 'e3bb227761e3ed239874e25da85e881cac32484d83293b50819e4865d867e1c7', text: () => import('./assets-chunks/index_server_html.mjs').then(m => m.default)},
    'index.html': {size: 13407, hash: 'ba0ed35de6c3e0be2d49f1fc72494532f0a7deb1037f8f4c293330df7efe7f5b', text: () => import('./assets-chunks/index_html.mjs').then(m => m.default)},
    'auth/login/index.html': {size: 13450, hash: '93f45071b3ff1e88025543158b54a5e112eebafa9f830d92fb6af06ec4f9a658', text: () => import('./assets-chunks/auth_login_index_html.mjs').then(m => m.default)},
    'dashboard/student/index.html': {size: 9318, hash: 'd7849419e41eda80419eca9d42ec5a4a22a10ff0627fa4a14cf8a708c630966e', text: () => import('./assets-chunks/dashboard_student_index_html.mjs').then(m => m.default)},
    'auth/register/index.html': {size: 14609, hash: '90b80c3f467c3905f2cb5d5a1ea4164cb69e7d425f2489cd6e1be5fa28b12262', text: () => import('./assets-chunks/auth_register_index_html.mjs').then(m => m.default)},
    'dashboard/admin/index.html': {size: 9318, hash: 'd7849419e41eda80419eca9d42ec5a4a22a10ff0627fa4a14cf8a708c630966e', text: () => import('./assets-chunks/dashboard_admin_index_html.mjs').then(m => m.default)},
    'admin/index.html': {size: 9318, hash: 'd7849419e41eda80419eca9d42ec5a4a22a10ff0627fa4a14cf8a708c630966e', text: () => import('./assets-chunks/admin_index_html.mjs').then(m => m.default)},
    'dashboard/teacher/index.html': {size: 9318, hash: 'd7849419e41eda80419eca9d42ec5a4a22a10ff0627fa4a14cf8a708c630966e', text: () => import('./assets-chunks/dashboard_teacher_index_html.mjs').then(m => m.default)},
    'student/index.html': {size: 9318, hash: 'd7849419e41eda80419eca9d42ec5a4a22a10ff0627fa4a14cf8a708c630966e', text: () => import('./assets-chunks/student_index_html.mjs').then(m => m.default)},
    'admin-dashboard/index.html': {size: 9318, hash: 'd7849419e41eda80419eca9d42ec5a4a22a10ff0627fa4a14cf8a708c630966e', text: () => import('./assets-chunks/admin-dashboard_index_html.mjs').then(m => m.default)},
    'teacher/index.html': {size: 9318, hash: 'd7849419e41eda80419eca9d42ec5a4a22a10ff0627fa4a14cf8a708c630966e', text: () => import('./assets-chunks/teacher_index_html.mjs').then(m => m.default)},
    'student-dashboard/index.html': {size: 9318, hash: 'd7849419e41eda80419eca9d42ec5a4a22a10ff0627fa4a14cf8a708c630966e', text: () => import('./assets-chunks/student-dashboard_index_html.mjs').then(m => m.default)},
    'student/timetable/index.html': {size: 9318, hash: 'd7849419e41eda80419eca9d42ec5a4a22a10ff0627fa4a14cf8a708c630966e', text: () => import('./assets-chunks/student_timetable_index_html.mjs').then(m => m.default)},
    'lecturer-dashboard/index.html': {size: 9318, hash: 'd7849419e41eda80419eca9d42ec5a4a22a10ff0627fa4a14cf8a708c630966e', text: () => import('./assets-chunks/lecturer-dashboard_index_html.mjs').then(m => m.default)},
    'styles-P5VQZ3JO.css': {size: 231381, hash: 'JgfuPaOn+A8', text: () => import('./assets-chunks/styles-P5VQZ3JO_css.mjs').then(m => m.default)}
  },
};
