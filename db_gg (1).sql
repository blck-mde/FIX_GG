-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 25, 2025 at 09:28 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_gg`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_user`
--

CREATE TABLE `tbl_user` (
  `user_id` int(11) NOT NULL,
  `nama_lengkap` varchar(50) NOT NULL,
  `username` varchar(20) NOT NULL,
  `email` varchar(50) NOT NULL,
  `nomor_telepon` varchar(20) NOT NULL,
  `password` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_user`
--

INSERT INTO `tbl_user` (`user_id`, `nama_lengkap`, `username`, `email`, `nomor_telepon`, `password`) VALUES
(7, 'Vanessa Vena Febriani Sahetapy', 'shtpy', 'vena@gmail.com', '028312381', 'vanessa'),
(8, 'Mikha Shantana Miracles Kussoy', 'meguyu', 'mikha@gmail.com', '219830283', 'mika'),
(9, 'Niha Hardiyanti', 'nhardyy', 'hardiyanti@gmail.com', '3948230948', 'niha'),
(10, 'Avriel Parengkuan', 'el', 'parengkuan@gmail.com', '328-048304', 'avriel'),
(11, 'Preysi Leony Tentero', 'cys', 'tentero@gmail.com', '4802932', 'eci'),
(13, 'Christine Elvira Rengkung', 'Titin Rengkung', 'rengkung@gmail.com', '328493', 'titin'),
(14, 'Jennie Kim', 'jeykim', 'kim@gmail.com', '42034823', 'jennie'),
(15, 'Chelsea Rantung', 'cecey', 'rantung@gmail.com', '029384284', 'celsi'),
(17, 'Rose Waloan', 'roseyy', 'rose@gmail.com', '082038023', 'rose');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_userinfo`
--

CREATE TABLE `tbl_userinfo` (
  `id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `tipe_kulit` varchar(50) NOT NULL,
  `masalah_kulit` varchar(11) NOT NULL,
  `tgl_terakhir_mens` date NOT NULL,
  `siklus_mens` int(11) NOT NULL,
  `lama_mens` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_userinfo`
--

INSERT INTO `tbl_userinfo` (`id`, `user_id`, `tipe_kulit`, `masalah_kulit`, `tgl_terakhir_mens`, `siklus_mens`, `lama_mens`) VALUES
(15, 7, 'Kulit Kering', 'Kemerahan', '2025-04-24', 30, 5),
(22, 14, 'Kulit Kering', 'Kusam', '2025-04-20', 30, 7),
(23, 15, 'Kulit Kombinasi', 'Jerawat', '2025-04-23', 28, 6),
(24, 17, 'Kulit Berminyak', 'Kusam', '2025-04-25', 28, 5);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_user`
--
ALTER TABLE `tbl_user`
  ADD PRIMARY KEY (`user_id`),
  ADD UNIQUE KEY `username` (`username`),
  ADD UNIQUE KEY `email` (`email`),
  ADD UNIQUE KEY `nomor_telepon` (`nomor_telepon`);

--
-- Indexes for table `tbl_userinfo`
--
ALTER TABLE `tbl_userinfo`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unique_user_id` (`user_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_user`
--
ALTER TABLE `tbl_user`
  MODIFY `user_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT for table `tbl_userinfo`
--
ALTER TABLE `tbl_userinfo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `tbl_userinfo`
--
ALTER TABLE `tbl_userinfo`
  ADD CONSTRAINT `tbl_userinfo_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `tbl_user` (`user_id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
