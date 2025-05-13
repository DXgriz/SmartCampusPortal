export interface Booking {
  id?: number;
  userId: string;
  serviceId: number;
  bookingDate: string;  // ISO string
  status: 'pending' | 'approved' | 'rejected';
}
  