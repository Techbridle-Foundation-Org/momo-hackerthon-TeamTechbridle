
import { BrowserRouter, Route } from "react-router-dom";
import Dashboard from "./pages/Dashboard";
import MyStokvels from "./pages/MyStokvels";
import Investments from "./pages/Investments";
import Payments from "./pages/Payments";
import Reports from "./pages/Reports";
import Settings from "./pages/Settings";
import Sidebar from "./components/Sidebar";
import Navbar from "./components/Navbar";

function App() {
  return (
    <BrowserRouter>
      <div className="flex h-screen bg-gray-100">
        {/* Sidebar */}
        <Sidebar />

        {/* Main Content */}
        <div className="flex-1 flex flex-col">
          <Navbar />
          <main className="p-6 overflow-y-auto">
            <Route path="/" element={<Dashboard />} />
            <Route path="/mystokvels" element={<MyStokvels />} />
            <Route path="/investments" element={<Investments />} />
            <Route path="/payments" element={<Payments />} />
            <Route path="/reports" element={<Reports />} />
            <Route path="/settings" element={<Settings />} />
          </main>
        </div>
      </div>
    </BrowserRouter>
  );
}

export default App;
