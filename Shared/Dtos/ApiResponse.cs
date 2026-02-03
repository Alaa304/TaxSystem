namespace Shared.DTOs
{
    /// <summary>
    /// غلاف موحد لردود API
    /// </summary>
    /// <typeparam name="T">نوع البيانات المراد إرجاعها</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// هل العملية ناجحة؟
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// رسالة توضيحية للعملية
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// البيانات الفعلية
        /// </summary>
        public T? Data { get; set; }

        /// <summary>
        /// قائمة الأخطاء في حال فشل العملية
        /// </summary>
        public IEnumerable<string>? Errors { get; set; }

        /// <summary>
        /// Constructor للنجاح
        /// </summary>
        public ApiResponse(T data, string? message = null)
        {
            IsSuccess = true;
            Data = data;
            Message = message;
        }

        /// <summary>
        /// Constructor للفشل
        /// </summary>
        public ApiResponse(string message, IEnumerable<string>? errors = null)
        {
            IsSuccess = false;
            Message = message;
            Errors = errors;
        }
    }
}
